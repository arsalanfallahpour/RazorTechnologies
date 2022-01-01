using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.Core.THelper
{
    public interface IHtmlGeneratable
    {
        public ILayoutString GetLayoutString();
    }
}