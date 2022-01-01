using System;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagContent : BaseStringModelValue, IHtmlTagContent
    {
        public HtmlTagContent(string htmlContent)
            : base(htmlContent)
        { }

        public bool IsValid() => HasValue();
    }
}