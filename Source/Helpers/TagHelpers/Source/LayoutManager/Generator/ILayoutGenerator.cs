using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace RazorTechnologies.TagHelpers.LayoutManager.Generator
{
    public interface ILayoutGenerator
    {
        public LayoutString GenerateLayout();
    }
}