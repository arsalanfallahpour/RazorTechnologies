using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface IButtonOptions
    {
        IHtmlTagAttrName ButtonName { get; }
        IHtmlTagAttrId ButtonId { get; }
        IHtmlTagAttrId FormId { get; }
    }
}