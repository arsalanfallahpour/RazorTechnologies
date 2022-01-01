using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Generator
{
    public interface ILayoutGeneratorOptions
    {
        public LayoutTypes LayoutType { get; }
        public string Title { get; }
        public IHtmlTagAttrId LayoutId { get; }
        public IHtmlTagAttrId LayoutFormId  { get; }
        public IHtmlTagAttrId LayoutContainerId { get; }
    }
}