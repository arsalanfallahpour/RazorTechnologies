using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutHeader : IHtmlGeneratable
    {
        public string Title { get; }
        public string SubTitle { get; }
        public ILayoutHeaderBreadcrumb Breadcrumb { get;}
        public LayoutHeaderData HeaderData { get; }
        bool IsAccepted();
    }
}