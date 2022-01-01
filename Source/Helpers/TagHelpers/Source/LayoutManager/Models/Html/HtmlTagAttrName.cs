using System;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagAttrName : HtmlTagAttribute, IHtmlTagAttrName
    {
        public HtmlTagAttrName(string htmlTagName)
            : base(htmlTagName)
        { }
        public HtmlTagAttrId TranslateToIdSyntax()
            => new HtmlTagAttrId(this.ToString().Replace('.', '_'));
        public override string AttributeName => "name";
    }
}