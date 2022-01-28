using MediatR;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.ScriptUtilities;
namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.CheckBox
{
    public class CheckBoxControl : BaseInputControl<CheckboxControlVMAttribute>
    {
        public override UiInputControlTypes UiInputControlType => UiInputControlTypes.checkbox;

        // use IArgumentMetadata argumentMetadata in builder of this class
        public CheckBoxControl(ILayoutInputControlOptions options)
            : base(options)
        {
        }

        //public static string GetHtmlRequestFormCheckboxContent(string tagUniqueId,
        //                                           string tagId,
        //                                           string tagName,
        //                                           string lable,
        //                                           bool disabled,
        //                                           bool initialChecked,
        //                                           CheckboxControlVMAttribute attribute)

        public override  IHtmlTagContent GetHtmlTagContent(IValueModel valueModel)
        {
            var value = valueModel.Content.ToString();
            if (!bool.TryParse(value, out var parsedValue))
                parsedValue = false;

            var sb = new StringBuilder();
            sb.Append(" <div class='form-check  mb-3 pt-1' style='position: relative;'>");
            sb.AppendFormat("<label for='{0}' class='form-check-label' style='margin-top: 10px;'> {1} </label>", Options.HtmlTag.UniqueId, Options.HtmlTag.Lable);
            var checkedText = RenderHtmlElementCheckedAttribute(false);
            var disabledText = RenderHtmlElementDisabledAttribute(true);

            sb.AppendFormat("<input type='checkbox' id='{0}' name='{1}' {4} value='' placeholder='...' class='form-check-input' style='margin-top: 8px!important; padding-right: 19px!important;padding-top: 19px !important;'  {2} {3}/>", Options.HtmlTag.UniqueId, Options.HtmlTag.Name, checkedText, disabledText, RenderHtmlElementAttribute(Options.HtmlTag.Form, Options.HtmlTag.Form));

            var jqArrayVarDependentFields = $"jqVarCheckBoxDependentFields_{Options.HtmlTag.UniqueId}";
            var jqArrayVarReversedDependentFields = $"jqVarCheckBoxReversedDependentFields_{Options.HtmlTag.UniqueId}";
            var jqVarNameIsEnumerated = $"isEnumerated_{Options.HtmlTag.UniqueId}";


            sb.Append(" <script>");
            sb.Append($"var {jqVarNameIsEnumerated} = false;");
            if(Attribute.ApplyMemberConditionTo == CheckboxApplyMemberCondition.AllMembers ||
            Attribute.ApplyMemberConditionTo == CheckboxApplyMemberCondition.ReverseDependentMembers)
            {
                sb.Append("$(document).ready(function()");
                sb.Append('{');
                sb.Append($"applyReversedDependentFields_{Options.HtmlTag.UniqueId}();");
                sb.Append("});");
            }

            var jqVarNameTag = "jqVarCheckBox";
            sb.Append($"var {jqVarNameTag} = $('#{Options.HtmlTag.UniqueId}');");
            switch(Attribute.ApplyMemberConditionTo)
            {
                case CheckboxApplyMemberCondition.NoneOfMembers:
                    break;

                case CheckboxApplyMemberCondition.DependentMembers:
                    sb.Append($"{RenderDependentTagToggleScript(Options.BindingViewModelOption.ApiParameterName, $"applyDependentFields_{Options.HtmlTag.UniqueId}", Attribute.DependentMemberNames, $"{jqVarNameIsEnumerated}", false)}");
                    sb.Append($"{jqVarNameTag}.click(()=>{{ applyDependentFields_{Options.HtmlTag.UniqueId}();}});");
                    break;
                case CheckboxApplyMemberCondition.ReverseDependentMembers:
                    Attribute.ValidateMemebers();
                    sb.Append($"{RenderDependentTagToggleScript(Options.BindingViewModelOption.ApiParameterName, $"applyReversedDependentFields_{Options.HtmlTag.UniqueId}", Attribute.ReversedDependentMemberNames, $"{jqVarNameIsEnumerated}", true)}");
                    sb.Append($"{jqVarNameTag}.click(()=>{{applyReversedDependentFields_{Options.HtmlTag.UniqueId}();}});");
                    break;
                case CheckboxApplyMemberCondition.AllMembers:
                    Attribute.ValidateMemebers();
                    sb.Append($"{RenderDependentTagToggleScript(Options.BindingViewModelOption.ApiParameterName, $"applyDependentFields_{Options.HtmlTag.UniqueId}", Attribute.DependentMemberNames, $"{jqVarNameIsEnumerated}", false)}");
                    sb.Append($"{RenderDependentTagToggleScript(Options.BindingViewModelOption.ApiParameterName, $"applyReversedDependentFields_{Options.HtmlTag.UniqueId}", Attribute.ReversedDependentMemberNames, $"{jqVarNameIsEnumerated}", true)}");
                    sb.Append($"{jqVarNameTag}.click(()=>{{applyDependentFields_{Options.HtmlTag.UniqueId}();}});");
                    sb.Append($"{jqVarNameTag}.click(()=>{{applyReversedDependentFields_{Options.HtmlTag.UniqueId}();}});");
                    //sb.Append($"{jqVarNameTag}.click(applyDependentFields_{Options.HtmlTag.UniqueId});");
                    //sb.Append($"{jqVarNameTag}.click(applyReversedDependentFields_{Options.HtmlTag.UniqueId});");
                    break;
                default:
                    throw new NotSupportedException(nameof(Attribute.ApplyMemberConditionTo));
            }
            sb.Append($"switch({(int)Attribute.ApplyMemberConditionTo})");
            sb.Append('{');
            sb.Append($"case {(int)CheckboxApplyMemberCondition.NoneOfMembers}:");
            sb.Append("break;");
            sb.Append($"case {(int)CheckboxApplyMemberCondition.DependentMembers}:");
            sb.Append($"applyDependentFields_{Options.HtmlTag.UniqueId}();");
            sb.Append("break;");
            sb.Append($"case {(int)CheckboxApplyMemberCondition.ReverseDependentMembers}:");
            sb.Append($"applyReversedDependentFields_{Options.HtmlTag.UniqueId}();");
            sb.Append("break;");
            sb.Append($"case {(int)CheckboxApplyMemberCondition.AllMembers}:");
            sb.Append($"applyDependentFields_{Options.HtmlTag.UniqueId}();");
            sb.Append($"applyReversedDependentFields_{Options.HtmlTag.UniqueId}();");
            sb.Append("break;");
            sb.Append('}');
            sb.Append(" </script>");

            sb.Append(" </div>");
            return new HtmlTagContent(sb.ToString());
        }
        //private string RenderDependentTagToggleScript(string funcName, IList<string> members, bool isReversed)
        //{
        //    var sb = new StringBuilder();
        //    sb.Append($"function {funcName} (){{");
        //    sb.Append($"{RenderJsArray("membersArray", members)}");
        //    sb.Append("membersArray.forEach(element => {");
        //    sb.Append("var jqField = $('[name = \\\'' + element + '\\\']'); ");
        //    sb.Append("});");
        //    sb.Append("}");
        //    return sb.ToString();
        //}
        public static string RenderDependentTagToggleScript(string bindingModelName, string funcName, IList<string> members, string jqVarNameisEnumerated, bool isReversed)
        {
            var sb = new StringBuilder();
            sb.Append($"function {funcName} (){{");
            sb.Append($"{RenderJsArray("membersArray", bindingModelName, members)}");
            sb.Append("membersArray.forEach(element => {");
            sb.Append("var jqField = $('[name = \\\'' + element + '\\\']'); ");
            sb.Append($"if({GetJsBoolean(isReversed)})");
            sb.Append('{');
            sb.Append($"if(!{jqVarNameisEnumerated}){{{jqVarNameisEnumerated} = true;element.disabled = true;jqField.parent().fadeOut().addClass('collapse');}}");
            sb.Append('}');
            sb.Append($"else");
            sb.Append('{');
            sb.Append($"if(!{jqVarNameisEnumerated}){{{jqVarNameisEnumerated} = true;jqField.parent().fadeIn().removeClass('collapse');}}");
            sb.Append('}');
            sb.Append("element.disabled = !element.disabled;");
            sb.Append("jqField.parent().fadeToggle(223, ()=>{});");
            sb.Append("});");
            sb.Append("}");
            return sb.ToString();
        }
        
    }
}
