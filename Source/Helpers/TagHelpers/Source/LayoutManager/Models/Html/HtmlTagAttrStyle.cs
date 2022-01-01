namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagAttrStyle : HtmlTagAttribute, IHtmlTagAttrStyle
    {
        public HtmlTagAttrStyle(string tagSriptContent)
            : base(tagSriptContent)
        { }
        public override string AttributeName => "style";
    }
}