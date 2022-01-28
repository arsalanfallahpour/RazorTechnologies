using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetCenter.Core;

using RazorTechnologies.Core;
using RazorTechnologies.TagHelpers.Core;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Html.Form;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.HtmlForm;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.ScriptUtilities;
namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public class LayoutBody : ILayoutBody
    {
        public LayoutBody(LayoutTypes layoutType)
        {
            LayoutType = layoutType;
        }
        public const string ValidatorFuncName = "sbem";

        public HtmlForm Form { get; private set; }
        public IHtmlTagAttrId FormId => Form?.HtmlTag?.Id;
        public IReadOnlyList<ILayoutScope> Scopes => _scopes;
        private readonly List<LayoutScope> _scopes = new();
        public const string AltFormPrefix = "altf_";
        public const string FormValidatiorPrefix = "sve_";
        public const string FormValidatiorLayoutContextPrefix = "fvlcnxt_";
        public const string FormValidatiorTagContextPrefix = "fvtcnxt_";
        public const string FormValidatorRendererPrefix = "sjfv_";
        public LayoutTypes LayoutType { get; }
        public LayoutApiModel LayoutApiModel { get; private set; }
        public void LoadApiModel(LayoutApiModel apiModel)
        {
            LayoutApiModel = apiModel ?? throw new ArgumentNullException(nameof(apiModel));
            var tag = NewTagForm(new HtmlTagFormContent(string.Empty));
            Form = new HtmlForm(tag, new HtmlFormOptions(LayoutApiModel.RelativePath, LayoutApiModel.HttpMethod));
        }
        public ILayoutString GetLayoutString()
        {
            var sb = new StringBuilder();
            sb.Append($"<div id=\'{FormValidatiorLayoutContextPrefix}{LayoutApiModel.LayoutId}\' style=\'width:100%;\'>");
            sb.Append(Form.GenerateLayout());
            sb.Append(GetScopeGroupsLayoutString());
            sb.Append("</div>");
            return new LayoutString(sb.ToString());
        }
        private LayoutString GetScopeGroupsLayoutString()
        {
            if (LayoutApiModel == null)
                throw new NullReferenceException(nameof(LayoutApiModel));

            if (LayoutApiModel.IsParameterless)
                throw new Exception(nameof(LayoutApiModel.IsParameterless));

            if (LayoutApiModel.MetadataAttribute.IgnoreParametersDiscovery)
                throw new Exception(nameof(LayoutApiModel.IsParameterless));

            var enumParameters = LayoutApiModel.DataParameters
                .Where(o => o.IsSupportViewModel)
                .OrderBy(o => o.ApiParameterOrder)
                .GetEnumerator();
            var sb = new StringBuilder();
            while (enumParameters.MoveNext())
            {
                var parameter = enumParameters.Current;
                var scope = new LayoutScope(LayoutApiModel.ApiType == Common.ApiTypes.Read, LayoutApiModel.MetadataAttribute.IgnoreParametersDiscovery);
                // TODO Make Unique Ids
                sb.Append($"<div  id='lb_main' class='' style=''>");
                sb.Append(RenderScrips());
                sb.Append(scope.GetLayoutString(ref parameter));
                sb.Append($"<div id='{AltFormPrefix}{LayoutApiModel.LayoutContainerId}'></div>");
                sb.Append($"<div id='slcm_{LayoutApiModel.LayoutContainerId}'></div>");
                sb.Append("</div>");
            }
            return new LayoutString(sb.ToString());
        }
        public string RenderScrips()
        {

            var sb = new StringBuilder();
            sb.Append($"<script>");
            sb.Append($"{RenderJsFormValidator($"{FormValidatiorPrefix}{LayoutApiModel.LayoutId}", $"{FormValidatorRendererPrefix}{LayoutApiModel.LayoutId}")}");
            sb.Append(RenderJqShowBusinessErrors($"{ValidatorFuncName}_{LayoutApiModel.LayoutId}"));



            sb.Append("function alertSomeThingWentWrong() { alert(\'Something went wrong with layout generator\');}");
            sb.Append("function alertRequestModelNotValid() { alert(\'Request Model Not Valid\');}");

            sb.Append(RenderJsRedirectToUri($"rtu_{LayoutApiModel.LayoutId}"));


            sb.Append($"var jqElementForm = $('#{LayoutApiModel.LayoutFormId}'); jqElementForm.submit(function(event){{ ");

            sb.Append($"{RenderJqFieldById("jqFieldBusinessMessageContainer", $"slcm_{LayoutApiModel.LayoutContainerId}")}");
            //Clear BusinessMessages
            sb.Append("jqFieldBusinessMessageContainer.html('');");

            sb.Append($"function ars_{LayoutApiModel.LayoutId}(data, status, object) {{ ");
            sb.Append($"if(status === 'success' && data.isModelValid === false){{ {ValidatorFuncName}_{LayoutApiModel.LayoutId}(data.businessErrorMessages); }}");

            sb.Append($"else  if(status === 'success' && data.{nameof(BaseAppResponseViewModel.IsModelValid).FromPascalToCamelCase()} === true && data.{nameof(BaseAppResponseViewModel.IsSuccessful).FromPascalToCamelCase()} == false){{");
            sb.Append($"{ValidatorFuncName}_{LayoutApiModel.LayoutId}(data.businessErrorMessages);");
            sb.Append('}');

            sb.Append($"else  if(status === 'success' && data.{nameof(BaseAppResponseViewModel.IsModelValid).FromPascalToCamelCase()} === true && data.{nameof(BaseAppResponseViewModel.IsSuccessful).FromPascalToCamelCase()} == true){{");
            sb.Append($"if(redirectUri{LayoutApiModel.LayoutFormId} === \'null\'){{ redirectUri{LayoutApiModel.LayoutFormId} = data.{(nameof(BaseAppResponseViewModel.ReturnUrl).FromPascalToCamelCase())}; }}");
            sb.Append($"rtu_{LayoutApiModel.LayoutId}(redirectUri{LayoutApiModel.LayoutFormId});");
            sb.Append('}');
            sb.Append($"else if(status !== 'success'){{  alertSomeThingWentWrong(); }}");
            sb.Append('}');
            sb.Append($"function are_{LayoutApiModel.LayoutId}(data, status, object) {{  if(request.status === 400){{  {FormValidatiorPrefix}{LayoutApiModel.LayoutId}(request.responseJSON.errors, '{FormValidatiorLayoutContextPrefix}{LayoutApiModel.LayoutId}');}}}}");
            sb.Append($"{RenderJqAjaxPostRequest($"aj_{LayoutApiModel.LayoutId}", $"ars_{LayoutApiModel.LayoutId}", $"are_{LayoutApiModel.LayoutId}", $"{LayoutApiModel.RelativePath}", GetJsAjaxDataObjectFromFormFields(LayoutApiModel.ExportDataParameters(), new()), LayoutApiModel.ExportDataParameters())}");
            sb.Append($"event.preventDefault();");
            sb.Append($"aj_{LayoutApiModel.LayoutId}();");
            sb.Append("}) </script>");
            return sb.ToString();
        }
        private string RenderJqShowBusinessErrors(string funcName)
        {
            var sb = new StringBuilder();
            sb.Append($"function {funcName}(messages) {{ ");
            sb.Append($"{RenderJqFieldById("jqFieldBusinessMessageContainer", $"slcm_{LayoutApiModel.LayoutContainerId}")}");
            sb.Append("for(z=0;z<messages.length;z++){");
            sb.Append($"jqFieldBusinessMessageContainer.html('<span  ");
            sb.Append($"style=\\'width:100%; height:100%; padding:0; transition:all 1s linear; background-color:transparent; position:relative; font-size:.9rem; justify-self:center; transition:all 1s linear;\\'");
            sb.Append($" class=\\'input-group-text pt-1 text-small \\'>");
            sb.Append($"<span style=\\'color: rgb(236 16 61 / 67%); font-size: 1rem;  \\' class=\\'py-1 px-2\\'>'+messages[z]+'</span>');");
            sb.Append('}');
            sb.Append('}');
            return sb.ToString();
        }

        public static string RenderJsFormValidationErrors(string funcName)
        {
            var jqVarValidationWrapper = "jqVarValidationWrapper";
            var jqVarValidationContainer = "jqVarValidationContainer";
            var jqVarValidationBadge = "jqVarValidationBadge";

            var validationId = $"as{CuidGenerator.NewCuid(5)}";
            var validationWrapperId = $"{validationId}_'+formFieldName+'{ValidationWrapperPostFix}";
            var validationContainerId = $"{validationId}_'+order+'{ValidationContainerPostFix}";
            var validationBadgeId = $"{validationId}_'+order+'{ValidationBadgePostFix}";
            return $"function {funcName}(order, fieldTagName, message, contextId) {{ " +
                   $"let formFieldName = fieldTagName.replace('.', '_');" +
                   $"let formFieldValidationWrapperId = '{validationWrapperId}';" +
                   $"let formFieldValidationContainerId = '{validationContainerId}';" +
                   $"let formFieldValidationBadgeId = '{validationBadgeId}';" +
                   $"let jqformField = $('#' + contextId + ' [name=\\''+fieldTagName+'\\']').first();" +
                   $"var {jqVarValidationContainer} = $('#' + formFieldValidationContainerId);" +
                   $"var {jqVarValidationBadge} = $('#' + formFieldValidationBadgeId);" +
                   $"var {jqVarValidationWrapper} = $('#' + formFieldValidationWrapperId);" +
                   "var isEarlyExist = false;" +
                   $"$('#' + formFieldValidationWrapperId + ' div' + '[id*={ValidationContainerPostFix}]').each((a, b)=>{{ isEarlyExist |= $(b).html() ===  message;}});" +
                   $"if(message !== \'\')" +
                   "{" +
                   "if(isEarlyExist === false){" +
                       $"if({jqVarValidationWrapper}.length === 0){{" +
                       $"{RenderValidationWrapper()}" +
                        $"{jqVarValidationWrapper} = $('#' + formFieldValidationWrapperId);" +
                       "}" +
                       $"{RenderValidationContainer()}" +
                       $"jqformField.css( 'outline', 'none');" +
                       $"{RenderValidationBadge()}" +
                   $"jqformField.click(function(){{}});" +
                   "}" +
                   "}" +
                      "}";

            string RenderValidationBadge()
                => $"jqformField.before('" +
                       $"<a data-bs-toggle=\\'collapse\\' role=\\'button\\' aria-expanded=\\'false\\' aria-controls=\\'{validationWrapperId}\\'  href=\\'#{validationWrapperId}\\' id=\\'{validationBadgeId}\\' " +
                       $"style=\\'display:inline-block; width:30px; height:30px; padding:0; transition:all 1s ease-out;position: absolute; right:0; transform: translate(30px, 2px); background-repeat:no-repeat;background-size:contain;background-image:url(\\/images\\/themes\\/warning_shield.svg)\\'" +
                       $" class=\\'pulse pulse-warning pulse-slow badge bg-transparent rounded px-2\\'></a>');";

            string RenderValidationWrapper()
                => $"jqformField.parent().append('<div id=\\'{validationWrapperId}\\' style=\\'transition:all 500ms ease-out;width:100%; font-size:.8rem;\\' class=\\'collapse\\' ></div>');";
            string RenderValidationContainer()
             => $"jqVarValidationWrapper.append('<div id=\\'{validationContainerId}\\' style=\\'transition:all 256ms ease-out;width:100%; border: 1px solid coral;border-radius: 0;border-top: 0;\\' class=\\'card card-body bg-transparent\\'>'+message+'</div>');";
        }
        public static string RenderJqClearValidation()
        {
            return $"let containers = $('[id*=\\'{ ValidationContainerPostFix}\\']'); " +
                 $"containers.fadeOut({ValidationFadeoutTime});" +
                 $"let wrappers = $('[id*=\\'{ ValidationWrapperPostFix}\\']');" +
                 $"wrappers.slideUp({ValidationSlideUpTime}, ()=>{{" +
                     $"wrappers.remove();" +
                     $"$('[id*=\\'{ ValidationBadgePostFix}\\']').remove();" +
                     $"" +
                 "});";
        }
        public const byte ValidationFadeoutTime = 45;
        public const byte ValidationSlideUpTime = 75;
        public const byte validationClearTime = ValidationFadeoutTime + ValidationSlideUpTime;
        public const string ValidationWrapperPostFix = "__vw";
        public const string ValidationContainerPostFix = "_vc";
        public const string ValidationBadgePostFix = "_vb";
        public static  string RenderJsFormValidator(string funcName, string validatorFuncName)
            => $"{RenderJsFormValidationErrors(validatorFuncName)}" +
                $"function {funcName}(errorArray, contextId) {{  " +
                     $"var message = '';" +
                            $"var errorKeys = Object.keys(errorArray);" +
                             $" for(d=0;d<errorKeys.length;d++)" +
                              "{" +
                                     $"var currentInnerError = errorArray[errorKeys[d].toString()];" +
                                     $" for(h=0;h<currentInnerError.length;h++)" +
                                      "{" +
                                            $"let currentInnerErrorMessage  = currentInnerError[h];" +
                                            $"let tagName  = errorKeys[d];" +
                                              $"message = ((currentInnerErrorMessage === undefined) ? '' : currentInnerErrorMessage);" +
                                              $"{validatorFuncName}(h,  tagName, message, contextId);" +

                                      "}" +
                             "}" +
                 "}";
        public HtmlTagForm NewTagForm(HtmlTagFormContent htmlTagFormContent)
        {


            string relativePath = LayoutApiModel.RelativePath.StartsWith('/') ? LayoutApiModel.RelativePath : LayoutApiModel.RelativePath.Insert(0, "/") ;
            var formTag = new HtmlTagForm(new HtmlTagAttrMethod(LayoutApiModel.HttpMethod),
                                          new HtmlTagAttrAction(relativePath),
                                          LayoutApiModel.LayoutFormId,
                                          LayoutApiModel.LayoutFormName,
                                          new HtmlTagAttrClass("w-100 bg-transparent p-5"),
                                          new HtmlTagAttrScript(string.Empty),
                                          new HtmlTagAttrStyle(string.Empty),
                                          htmlTagFormContent,
                                          new StringValueModel(LayoutApiModel.Title)
                                          );
            return formTag;
        }
    }
}