namespace RazorTechnologies.TagHelpers.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    using RazorTechnologies.TagHelpers.Core.THelper;
    using RazorTechnologies.TagHelpers.LayoutManager;
    using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
    using RazorTechnologies.TagHelpers.LayoutManager.Models;
    using static RazorTechnologies.TagHelpers.LayoutManager.Models.LayoutApiSnapshotExtensions;
    public abstract class BaseFormRequestTagHelper<TRequestViewModel>
        : BaseRequestTagHelper, IFormRequestTagHelper
        where TRequestViewModel : BaseAppRequestViewModel
    {
        public BaseFormRequestTagHelper(ILayoutManager layoutManager)
            : base(layoutManager)
        {
            if (RequestViewModelType is null)
                throw new TargetException("RequestViewModel type has no property");
        }
        public virtual string RequestFormId => $"{RequestViewModelName.ToLower()}-form";
        public virtual string AlternateFormsWrapperId => $"{RequestFormId}_AlternateFormWrapperId";
        //ViewModel Guid 
        //ViewModelProperty Name
        public abstract JsBindedModelValues JsBindedModelValues { get; set; }
        public abstract string ReturnUrl { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var layout = LayoutManager.GetLayoutString();
            var sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append($"var redirectUri{LayoutManager.Options.LayoutFormId} = \'null\';");
            sb.Append("$(document).ready(function(){ ");
            //sb.Append($"document.getElementById('sid_{LayoutManager.Options.LayoutFormId}').innerText = '{SubmitButtonText}';" );
            sb.Append($"$('#sid_{LayoutManager.Options.LayoutFormId}').text('{SubmitButtonText}');");
            if (!string.IsNullOrEmpty(ReturnUrl))
                sb.Append($"redirectUri{LayoutManager.Options.LayoutFormId} = \'{ReturnUrl}\';");
            sb.Append(" });");
            sb.Append("</script>");
            sb.Append($"<div id='{InnerContainerIdPrefix}{LayoutManager.Options.LayoutContainerId}'>");
            sb.Append(layout.Content);
            sb.Append("</div>");
            sb.Append(RenderJsBindedModelValuesScript());
            output.Content.SetHtmlContent(sb.ToString());
            return base.ProcessAsync(context, output);
        }

        private string RenderJsBindedModelValuesScript()
        {
            if (JsBindedModelValues is null || JsBindedModelValues.Count < 1)
                return string.Empty;

            var sb = new StringBuilder();
            sb.Append("<script> $(document).ready(function(){");
            var enumJsBindedModelValues = JsBindedModelValues.GetEnumerator();
            while (enumJsBindedModelValues.MoveNext())
            {
                var current = enumJsBindedModelValues.Current;
                // TODO ApiSnapShotModelId
                var parameter = GetBindedParameter(current.ViewModelTypeGuid);
                if (parameter is null)
                    continue;
                var property = parameter.GetBindedProperty(current.PropertyName);

                if (property is null)
                    continue;

                sb.Append($"let jqVar_dv_{property.UiControlId}_as = $('#{property.UiControlId}');");

                switch (property.UiInputControlType)
                {
                    case UiInputControlTypes.text:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case UiInputControlTypes.email:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case UiInputControlTypes.tel:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case UiInputControlTypes.checkbox:
                        if (!bool.TryParse(current.PropertyValue, out var @checked))
                            throw new Exception("Wrong value passed into model");
                        var value = @checked ? "true" : "false";
                        //sb.Append($"$('#{property.UiControlId}').prop('checked','{value}');");
                        sb.Append($"let isChecked_{property.UiControlId} = jqVar_dv_{property.UiControlId}_as.prop('checked');");
                        sb.Append($"if(isChecked_{property.UiControlId} === false && {@checked.ToString().ToLower()} == true){{");
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.click();");
                        sb.Append('}');
                        //sb.Append($"$('#{property.UiControlId}').attr('checked','{value}');");
                        break;
                    case UiInputControlTypes.number:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case UiInputControlTypes.range:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case UiInputControlTypes.password:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case UiInputControlTypes.hidden:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case UiInputControlTypes.select:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    default:
                        throw new Exception("Unkown Controls cannot accept Value from ui");
                }
                if(current.UiForcedDisabled && property.UiInputControlType != UiInputControlTypes.hidden)
                    sb.Append($"jqVar_dv_{property.UiControlId}_as.prop('disabled', true);");

            }

            sb.Append("});</script>");
            return sb.ToString();
        }
        private LayoutApiSnapshot.LayoutApiParameterSnapshot GetBindedParameter(Guid targetViewModelTypeGuid)
        {
            return LayoutManager.Options.LayoutGeneratorOutput?.DataBindings
                                ?.Where(o => o?.ApiParameterRquestViewModelType?.GUID.CompareTo(targetViewModelTypeGuid) == 0)?.FirstOrDefault();
        }

        //All Fields
        #region Properties Fields
        public virtual string RequestViewModelName => RequestViewModelType.Name;
        public override string TargetRequestModelTargetBindingArgumentName => RequestViewModelName;
        public virtual Type RequestViewModelType => typeof(TRequestViewModel);
        #endregion

    }
}
