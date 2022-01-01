using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls
{
    public interface ILayoutHtmlGenerator
    {
        public ILayoutString GenerateLayout();
        //public IHtmlGenerator HtmlGenerator { get; }
    }
}