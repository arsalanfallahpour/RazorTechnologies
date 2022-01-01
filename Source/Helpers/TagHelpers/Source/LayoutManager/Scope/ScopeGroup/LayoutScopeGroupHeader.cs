using System.Text;

using RazorTechnologies.TagHelpers.LayoutManager.Generator;

namespace RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup
{
    public class LayoutScopeGroupHeader : ILayoutScopeGroupHeader
    {
        public string Title { get; }
        public string Subtitle { get; }
        public string Description { get; }
        public ILayoutString GetLayoutString()
        {
            var sb = new StringBuilder();
            sb.Append("<div id='lbsgh_cont' class='' style=''>");
            sb.Append("</div>");
            return new LayoutString(sb.ToString());
        }

    }
}