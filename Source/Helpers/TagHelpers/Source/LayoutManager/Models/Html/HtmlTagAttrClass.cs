namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagAttrClass : HtmlTagAttribute, IHtmlTagAttrClass
    {
        public HtmlTagAttrClass(string classContent)
            : base(classContent)
        { }
        public override string AttributeName => "class";

    }
}