using System.Text;

using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup
{
    public class LayoutScopeGroupFooter : ILayoutScopeGroupFooter
    {
        public ILayoutString GetLayoutString()
        {
            var sb = new StringBuilder();
            sb.Append("<div id='lbsgf_cont' class='' style=''>");
            sb.Append("</div>");
            return new LayoutString(sb.ToString());
        }
    }
}