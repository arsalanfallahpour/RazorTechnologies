using MediatR;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Options;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using System;
using System.Text;
using System.Threading.Tasks;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Range
{
    public class RangeControl : BaseInputControl<RangeControlVMAttribute>
    {
        // use IArgumentMetadata argumentMetadata in builder of this class
        public override UiInputControlTypes UiInputControlType => UiInputControlTypes.range;
        public RangeControl(ILayoutInputControlOptions options)
            : base(options)
        {
        }


        //public static string GetHtmlRequestFormTextFieldContent(string tagUniqueId, string tagId, string tagName, string lable, bool required, bool disabled, string initialValue)
        public override  IHtmlTagContent GetHtmlTagContent(IValueModel modelValue)
        {
            var sb = new StringBuilder();
            sb.Append(" <div class='input-group mb-4' style='position: relative;'>");
            sb.AppendFormat("<label for='{0}' class='input-group-text' style='max-width:200px;'> {1} </label>", Options.HtmlTag.UniqueId, Options.HtmlTag.Lable);
            sb.Append($"<input type='range' class='range range-sm' id='{Options.HtmlTag.UniqueId}' {RenderHtmlElementAttribute(Options.HtmlTag.Form, Options.HtmlTag.Form)} value='{modelValue.Content}' style='' {RenderHtmlElementDisabledAttribute(!Options.ForceDisabled)}/>");
            sb.Append(" </div>");
            return new HtmlTagContent(sb.ToString());
        }
    }
}
