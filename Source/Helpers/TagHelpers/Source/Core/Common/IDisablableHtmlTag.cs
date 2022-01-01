using RazorTechnologies.TagHelpers.LayoutManager.Controls;

namespace RazorTechnologies.TagHelpers.Core.Common
{
    public interface IDisableableHtmlTag
    {
        public bool ForceDisabled { get; }
    }
}