using System;
using System.Text;

using DotNetCenter.Core;

using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup
{
    public class LayoutScopeGroupBody : BaseLayoutHtmlTag, ILayoutScopeGroupBody
    {
        public LayoutScopeGroupBody()
        {
            _htmlTag = new HtmlTagModel(string.Empty);
        }
        public IHtmlTag HtmlTag => _htmlTag;
        protected readonly HtmlTagModel _htmlTag;
        public ILayoutString GetLayoutString()
        {
            var sb = new StringBuilder();
            //var enumScopes = Scopes.GetEnumerator();
            //while (enumScopes.MoveNext())
            //    sb.Append(enumScopes.Current.GetLayoutString());
            sb.Append("<div id='lbsg_cont' class='' style=''>");
            sb.Append("</div>");
            return new LayoutString(sb.ToString());
        }
        public  HtmlTagContent NewTagContent()
        {
            var sb = new StringBuilder();
            //~~?
            return new HtmlTagContent(sb.ToString());
        }
        public override HtmlTagModel NewHtmlTag(HtmlTagContent htmlTagContent)
        {
            HtmlTagModel htmlTag = new HtmlTagModel(String.Empty);
            htmlTag.SetName(new HtmlTagAttrName(string.Empty));
            htmlTag.SetTagId(new HtmlTagAttrId("lbsgb_cont"));
            htmlTag.SetTagClass(new HtmlTagAttrClass("w-100 bg-transparent p-4"));
            htmlTag.SetTagScript(new HtmlTagAttrScript(String.Empty));
            htmlTag.SetTagContent(htmlTagContent);
            htmlTag.SetTagName(new HtmlTagContent("div"));
            return htmlTag;
        }
        public override HtmlTagAttrName NewTagName()
            => throw new NotImplementedException();
        public override HtmlTagAttrId NewTagId()
            => throw new NotImplementedException();

    }
}