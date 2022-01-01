using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTechnologies.TagHelpers.LayoutManager;

namespace RazorTechnologies.TagHelpers.Core.THelper
{
    public interface AppTagHelper
    {
        public abstract string DefaultTagName { get; }
        public abstract string Description { get; }
        public abstract TagMode DefaultTagMode { get; }
        public ILayoutManager LayoutManager { get; }
    }
}