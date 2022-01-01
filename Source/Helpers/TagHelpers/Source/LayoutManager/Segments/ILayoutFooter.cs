using RazorTechnologies.TagHelpers.Core.THelper;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutFooter : IHtmlGeneratable
    {
        public LayoutFooterActionButtonWrapper ActionButtonWrapper { get; }
    }
}