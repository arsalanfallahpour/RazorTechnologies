using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public class ButtonOptions : IButtonOptions
    {
        public ButtonOptions(IHtmlTagAttrId formId, IHtmlTagAttrId id, IHtmlTagAttrId uniqueId, IHtmlTagAttrName name)
        {
            FormId = formId;
            ButtonId = id;
            UniqueId = uniqueId;
            ButtonName = name;
        }

        public IHtmlTagAttrId ButtonId { get; }
        public IHtmlTagAttrId UniqueId { get; }
        public IHtmlTagAttrId FormId { get; }
        public IHtmlTagAttrName ButtonName { get; }
    }
}