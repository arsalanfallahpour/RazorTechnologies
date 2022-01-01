using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public interface ILayoutControl
    {
        public ILayoutString GenerateLayout(IValueModel valueModel);
    }
}