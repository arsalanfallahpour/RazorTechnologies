using System.Text;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using Microsoft.Extensions.Primitives;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.SubmitButton
{
    public class LayoutSubmitButton : ILayoutSubmitButton
    {
        public LayoutSubmitButton(IButtonOptions options)
        {
            Options = options;
        }
        public IButtonOptions Options { get; }

        public ILayoutString GetLayoutString()
        {
            var sb = new StringBuilder();
            sb.Append("<button form='");
            sb.Append(Options.FormId);
            sb.Append('\'');
            sb.Append(RenderHtmlElementAttribute(Options.ButtonName, Options.ButtonName));
            sb.Append(RenderHtmlElementAttribute(Options.ButtonId, Options.ButtonId));
            var @class = new HtmlTagAttrClass("btn btn-small btn-success");
            sb.Append(RenderHtmlElementAttribute(@class, @class));
            var style = new HtmlTagAttrStyle("width:100%;");
            sb.Append(RenderHtmlElementAttribute(style, style));
            var script = new HtmlTagAttrScript(string.Empty);
            sb.Append(RenderHtmlElementAttribute(script, script));
            sb.Append(@" formtarget='_self' >");
            sb.Append("Submit");
            sb.Append("</button><br/>");
            return new LayoutString(sb.ToString());
        }

    }
}
