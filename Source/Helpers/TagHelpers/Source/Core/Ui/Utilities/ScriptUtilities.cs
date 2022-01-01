using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetCenter.Core;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models;

namespace RazorTechnologies.TagHelpers.Core.Ui.Utilities
{
    public static class ScriptUtilities
    {
        #region Javascript
        public static string GetJsAjaxDataObjectFromFormFields(LayoutApiSnapshot apiSnapshot, Dictionary<string, string> additionalData = null)
        {
            var apiParameters = apiSnapshot.GetEnumerator();
            var objCounter = 0;
            var sb = new StringBuilder();
            //if (apiSnapshot.Count > 1)
            sb.Append('{');
            while (apiParameters.MoveNext())
            {
                var parameter = apiParameters.Current;
                if (!parameter.IsSupportViewModel)
                    continue;

                var dataObjectProperties = parameter.Where(o => !o.IsCustomIgnored && !o.IsIgnoredBinding).ToArray();


                sb.Append(parameter.Name);

                //if (!parameter.IsSupportViewModel)
                //    continue;
                //{
                //    // TODO Test
                //    var value = GetJsFormControlValueVarName(parameter.Name);
                //    sb.Append($": {value}");
                //}
                //else
                //{

                    sb.Append(": {");
                    for (int i = 0; i < dataObjectProperties.Length; i++)
                    {
                        var prop = dataObjectProperties[i];
                        var value = GetJsFormControlValueVarName(prop.Name);
                        if (string.IsNullOrEmpty(value))
                            continue;

                        sb.Append(prop.Name);
                        sb.Append(':');
                        sb.Append(value);
                        if (i != (dataObjectProperties.Length - 1))
                            sb.Append(',');
                    }
                    if (additionalData is not null)
                    {
                        for (int i = 0; i < additionalData.Keys.Count; i++)
                        {
                            var properyName = additionalData.Keys.ElementAt(i);
                            var properyValue = additionalData[properyName];
                            if (string.IsNullOrEmpty(properyValue))
                                continue;
                            if (i == 0)
                                sb.Append(',');
                            sb.Append(properyName);
                            sb.Append(':');
                            sb.Append(properyValue);
                            if (i != (additionalData.Count - 1))
                                sb.Append(',');
                        }
                    }
                    sb.Append('}');
                //}

                if (objCounter != (apiSnapshot.Count - 1))
                    sb.Append(',');
                objCounter++;
            }
            //if (apiSnapshot.Count > 1)
            sb.Append('}');
            return sb.ToString();
        }
        public static string RenderJsArray(string varName, string bindingModelName, IList<string> array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            var arrayContent = new StringBuilder();
            arrayContent.Append($"var {varName} = [");

            int arrayCount = array.Count;
            for (int i = 0; i < arrayCount; i++)
            {
                arrayContent.Append('\'');
                //Test ????
                arrayContent.Append($"{bindingModelName}.{array[i]}");
                arrayContent.Append('\'');

                if (i != (arrayCount - 1))
                    arrayContent.Append(',');
            }
            arrayContent.Append("];");
            return arrayContent.ToString();
        }
        public static string JsFormControlNamePostfix => "FormCtrl";
        public static string JsFormControlNamePrefix => "jqVar";
        public static string JsFormControlValueVarNamePrefix => "jqVar";
        public static string JsFormControlValueVarNamePostfix => "FormCtrlVal";
        public static string GetJsFormControlVarName(string modelPropName) => $"{JsFormControlNamePrefix}{modelPropName}{JsFormControlNamePostfix}";
        public static string GetJsFormControlValueVarName(string modelPropName) => $"{JsFormControlValueVarNamePrefix}{modelPropName}{JsFormControlValueVarNamePostfix}";
        public static string GetJsFormControlValueProvider(LayoutControlTypes layoutControlType)
        {
            var func = String.Empty;
            switch (layoutControlType)
            {
                case LayoutControlTypes.Unkown:
                    throw new NotSupportedException();
                case LayoutControlTypes.TextBox:
                    func = ".val()";
                    break;
                case LayoutControlTypes.EmailBox:
                    func = ".val()";
                    break;
                case LayoutControlTypes.PhoneNumberBox:
                    func = ".val()";
                    break;
                case LayoutControlTypes.CheckBox:
                    func = $".prop('checked');";
                    break;
                case LayoutControlTypes.NumericBox:
                    func = ".val()";
                    break;
                case LayoutControlTypes.PersianDatePicker:
                    func = ".val()";
                    break;
                case LayoutControlTypes.Range:
                    func = ".val()";
                    break;
                case LayoutControlTypes.PasswordBox:
                    func = ".val()";
                    break;
                case LayoutControlTypes.ComparePasswordBox:
                    func = ".val()";
                    break;
                case LayoutControlTypes.DataViewLable:
                    func = ".val()";
                    break;
                default:
                    func = ".val()";
                    break;
            }
            return func;
        }
        public static string RenderJsFormFieldVariables(LayoutApiSnapshot apiSnapshot)
        {
            var enumDataObjects = apiSnapshot?.Where(o => o.IsSupportViewModel)?.GetEnumerator();
            if (enumDataObjects is null)
                return String.Empty;

            var sb = new StringBuilder();

            while (enumDataObjects.MoveNext())
            {
                var parameter = enumDataObjects.Current;
                var dataObjectProperties = parameter
                    ?.Where(
                    
                    
                o => 
                //o.LayoutControlType != LayoutControlType.DataViewLable
                    !o.IsCustomIgnored
                    && !o.IsIgnoredBinding
                    && o.LayoutControlType != LayoutControlType.Unknown
                )?.ToArray();
                if (dataObjectProperties is null)
                    return String.Empty;
                for (int i = 0; i < dataObjectProperties.Length; i++)
                {
                    var fieldName = dataObjectProperties[i];
                    sb.Append(RenderJqFormFieldVariables(fieldName.Name, parameter.Name));
                    sb.Append(RenderJqFormFieldValueVariables(fieldName.Name, fieldName.LayoutControlType.TypedValue));
                }
            }
            return sb.ToString();
        }
        public static string RenderJsRedirectToUri(string funcName, string uri)
            => $"function {funcName}() {{ window.location= window.location.origin + '{uri}';}}";
        public static string RenderJsRedirectToUri(string funcName)
            => $"function {funcName}(uri) {{ window.location= window.location.origin + uri;}}";

        public static string RenderJqFieldById(string fieldName, string elementId)
            => $"var {fieldName} = $('#' + '{elementId}');";

        public static object RenderJqFormFieldValueVariables(string fieldName, LayoutControlTypes layoutControlType) => $"var {GetJsFormControlValueVarName(fieldName)} = {GetJsFormControlVarName(fieldName)}{GetJsFormControlValueProvider(layoutControlType)};";
        public static object RenderjqVarById(string varName, string id) => $"var {varName} = $('#{id}');";

        //Test ???
        public static string RenderJqFormFieldVariables(string fieldName, string bindingModelName) => $"var { GetJsFormControlVarName(fieldName)} = {GetJqFormControlVarByTagName($"{bindingModelName}.{fieldName}")};";
        public static string GetJqFormControlVarByTagName(string formTagName) => $"$('[name=\\'{formTagName}\\']').first();";
        public static object RenderJqAjaxPostRequest(LayoutApiSnapshot layoutApiSnapshot,
                                                      string ajaxFuncName,
                                                      string successFuncName,
                                                      string errorFuncName,
                                                      string modelBindingGateway,
                                                      string data,
                                                      TargetBindingArgumentTypes bindingArgumentType,
                                                      IDictionary<string, string> additionalProps)
        {
            var sb = new StringBuilder();
            modelBindingGateway = modelBindingGateway.StartsWith('/') ? modelBindingGateway : modelBindingGateway.Insert(0, "/");

            sb.Append($"function {ajaxFuncName}() {{");
            sb.Append($"{LayoutBody.RenderJqClearValidation()}");
            sb.Append($"{RenderJsFormFieldVariables(layoutApiSnapshot)}");
            sb.Append($" request = ");
            sb.Append($"$.ajax({{");
            sb.Append($" url: '{modelBindingGateway}',");
            sb.Append($" type: '{layoutApiSnapshot.BindingApiOption.HttpMethod.Method}',");
            sb.Append($" data : {JsAppendPropertiesToFormPostData(data, additionalProps, bindingArgumentType)},");
            sb.Append($" error: {errorFuncName},");
            sb.Append($" success: {successFuncName}");
            sb.Append($"}});");
            sb.Append($";}}");
            return sb.ToString();
        }

        public static object RenderJqAjaxPostRequest(string ajaxFuncName,
                                                      string successFuncName,
                                                      string errorFuncName,
                                                      string modelBindingGateway,
                                                      string data,
                                                      LayoutApiSnapshot layoutApiSnapshot
                                                      )
        {
            modelBindingGateway = modelBindingGateway.StartsWith('/') ? modelBindingGateway : modelBindingGateway.Insert(0, "/");

            var funcBody = $"function {ajaxFuncName}_body() {{" +
                     $"{RenderJsFormFieldVariables(layoutApiSnapshot)}" +
                        $" request = " +
                            $"$.ajax({{" +
                                $" url: '{modelBindingGateway}'," +
                                $" type: '{layoutApiSnapshot.BindingApiOption.HttpMethod.Method}'," +
                                $" data : {data}," +
                                // $" cache: false, " +
                                //$"contentType: false, " +
                                //$"processData: false, " +
                                $" error: {errorFuncName}," +
                                $" success: {successFuncName}" +
                             $"}});" +
                        $";}}";


            var funcClear = RenderFuncClear(ajaxFuncName);

            var funcCaller = ClearSendAjax(ajaxFuncName, funcBody, funcClear);

            return funcCaller;
        }

        private static string RenderFuncClear(string ajaxFuncName)
        {
            return $"async function {ajaxFuncName}_clear(){{" +
                                $"{LayoutBody.RenderJqClearValidation()}" +
                        "};";
        }

        private static string ClearSendAjax(string ajaxFuncName, string funcBody, string funcClear)
        {
            return $"{funcBody} {funcClear} function {ajaxFuncName}(){{" +
                                   $"{ajaxFuncName}_clear().then(" +
                                   $"function(value){{ " +
                                    $"setTimeout(function(){{" +
                                        // TODO START Ajax Progressbar
                                        $"{ajaxFuncName}_body();" +
                                        // TODO END Ajax Progressbar
                                        $"}}, {LayoutBody.validationClearTime + 23});" +
                                   " }" +
                                   $", function(error){{alert('error occured on clear validations');}}" +
                            ");};";
        }

        public static object RenderJqAjaxPostFileRequest(string method,
                                                        string ajaxFuncName,
                                                     string successFuncName,
                                                     string errorFuncName,
                                                     string beforeSendFuncName,
                                                     string completeFuncName,
                                                     string xhrFuncName,
                                                     string modelBindingGateway,
                                                     string dataDefinition,
                                                     string dataVarname)
        {
            //modelBindingGateway = modelBindingGateway.StartsWith('/') ? modelBindingGateway.Remove(0, 1) : modelBindingGateway;
            string funcBody = $"function {ajaxFuncName}_body() {{" +
                              //$"{LayoutBody.RenderJqClearValidation()}" +
                              $"{dataDefinition}" +
                                   $"request = " +
                                  $"$.ajax({{" +
                                      $" url: '{modelBindingGateway}'," +
                                      $" type: '{method}'," +
                                      $" data : {dataVarname}," +
                                       $" cache: false, " +
                                       $"contentType: false," +
                                       $" processData: false, " +
                                      $" error: {errorFuncName}," +
                                      $" success: {successFuncName}," +
                                      $" beforeSend: {beforeSendFuncName}," +
                                      $" complete: {completeFuncName}," +
                                      $" xhr: {xhrFuncName}" +
                                   $"}});" +
                              $";}}";

            var funcClear = RenderFuncClear(ajaxFuncName);

            var funcCaller = ClearSendAjax(ajaxFuncName, funcBody, funcClear);

            return funcCaller;
        }

        public static string JsAppendPropertiesToFormPostData(string data, IDictionary<string, string> properties, TargetBindingArgumentTypes dataType)
        {
            var enumerator = properties.GetEnumerator();
            var modifiedData = string.Empty;
            while (enumerator.MoveNext())
            {
                if (dataType == TargetBindingArgumentTypes.IndividualFields)
                    modifiedData = data.Insert(data.Length - 2, $", {enumerator.Current.Key} : {enumerator.Current.Value}");
                else if (dataType == TargetBindingArgumentTypes.SingleObject)
                    modifiedData = data.Insert(data.Length - 1, $", {enumerator.Current.Key} : {enumerator.Current.Value}");
            }
            return modifiedData;
        }

        public static string GetSubmitButtonId(string formName) => $"{formName}-form-submit";


        public static string GetJsBoolean(bool boolean)
        {
            return boolean.ToString().ToLower();
        }
        #endregion
    }
}
