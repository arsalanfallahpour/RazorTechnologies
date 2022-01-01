namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagAttrScript : HtmlTagAttribute, IHtmlTagAttrScript
    {
        public HtmlTagAttrScript(string tagSriptContent)
            : base(tagSriptContent)
        { }
        public override string AttributeName => "script";
    }
}