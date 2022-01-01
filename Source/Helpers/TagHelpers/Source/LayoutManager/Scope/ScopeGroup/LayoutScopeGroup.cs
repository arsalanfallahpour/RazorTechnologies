using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotNetCenter.Core;
using DotNetCenter.Core.Guards;

using Microsoft.VisualBasic;

using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.Segments;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;

namespace RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup
{
    public class LayoutScopeGroup : BaseLayoutHtmlTag, ILayoutScopeGroup
    {
        public ILayoutScopeGroupHeader Header => header;
        private readonly LayoutScopeGroupHeader header = new();
        public ILayoutScopeGroupBody Body => body;
        private readonly LayoutScopeGroupBody body = new();
        public ILayoutScopeGroupFooter Footer => footer;
        private readonly LayoutScopeGroupFooter footer = new();
        public ILayoutString GetLayoutString(IEnumerable<ApiDataProperty> groupedProperties)
        {
            if (groupedProperties is null)
                throw new ArgumentNullException(nameof(groupedProperties));

            var sb = new StringBuilder();
            var content = NewTagContent();
            sb.Append(RenderHtmlTag(NewHtmlTag(content)));
            return new LayoutString(sb.ToString());
        }
        public override HtmlTagModel NewHtmlTag(HtmlTagContent htmlTagContent)
        {
            HtmlTagModel htmlTag = new HtmlTagModel(String.Empty);
            htmlTag.SetName(new HtmlTagAttrName(string.Empty));
            htmlTag.SetTagId(new HtmlTagAttrId("lbsg_wrapper"));
            htmlTag.SetTagClass(new HtmlTagAttrClass("d-none"));
            htmlTag.SetTagScript(new HtmlTagAttrScript(String.Empty));
            htmlTag.SetTagContent(htmlTagContent);
            htmlTag.SetTagName(new HtmlTagContent("div"));
            return htmlTag;
        }
        public override HtmlTagAttrName NewTagName()
            => throw new NotImplementedException();
        public  HtmlTagContent NewTagContent()
        {
            var sb = new StringBuilder();
            return new HtmlTagContent(sb.ToString());
        }
        public override HtmlTagAttrId NewTagId()
            => new();
    }
}
