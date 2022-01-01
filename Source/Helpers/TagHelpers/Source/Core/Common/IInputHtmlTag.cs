using RazorTechnologies.TagHelpers.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html.Form;

namespace RazorTechnologies.Core.Common
{
    public interface IInputHtmlTag : IHtmlTag
    {
        public bool Disabled { get; }
        public IHtmlTagAttrForm Form { get; }
    }
}