using System;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public class LayoutInputControlOptions : LayoutControlOptions, ILayoutInputControlOptions
    {
        public LayoutInputControlOptions(
            IHtmlTagAttrId layoutId,
            IHtmlTagAttrId layoutMessageContainerId,
            IBindingViewModelOption bindingViewModelOption, 
            IHtmlTagAttrId layoutFormId,
            IHtmlTagAttrName layoutFormName,
            Attribute attribute,
            IInputHtmlTag htmlTag, 
            TagHelperStates formState,
            bool forceDisabled)
            :base(layoutId,
                 layoutMessageContainerId,
                 bindingViewModelOption,
                 attribute,
                 htmlTag,
                 formState)
        {
            ForceDisabled = forceDisabled;
            LayoutFormId = layoutFormId ?? throw new ArgumentNullException(nameof(layoutFormId));
            LayoutFormName = layoutFormName ?? throw new ArgumentNullException(nameof(layoutFormName));
            HtmlTag = htmlTag ?? throw new ArgumentNullException(nameof(htmlTag));
        }

        public bool ForceDisabled { get; }
        public IHtmlTagAttrId LayoutFormId { get; }
        public IHtmlTagAttrName LayoutFormName { get; }
        public new IInputHtmlTag HtmlTag { get; }
    }
}