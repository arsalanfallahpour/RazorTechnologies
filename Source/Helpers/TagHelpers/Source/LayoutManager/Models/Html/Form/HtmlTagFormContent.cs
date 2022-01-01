using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagFormContent : BaseStringModelValue, IHtmlTagFormContent
    {
        public HtmlTagFormContent(string content) 
            : base(content)
        {
        }
    }
}