using System;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public class LayoutControlOptions : ILayoutControlOptions
    {

        public LayoutControlOptions(
                                    IHtmlTagAttrId layoutId,
                                    IHtmlTagAttrId layoutMessageContainerId,
            IBindingViewModelOption bindingViewModelOption,
                                    Attribute attribute,
                                    IHtmlTag htmlTag,
                                    TagHelperStates formState)
        {
            RequestState = formState;
            BindingViewModelOption = bindingViewModelOption ?? throw new ArgumentNullException(nameof(bindingViewModelOption));
            HtmlTag = htmlTag ?? throw new ArgumentNullException(nameof(htmlTag));
            Attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
            LayoutId = layoutId ?? throw new ArgumentNullException(nameof(layoutId));
            LayoutMessageContainerId = layoutMessageContainerId ?? throw new ArgumentNullException(nameof(layoutMessageContainerId));
        }
        public TagHelperStates RequestState { get; }
        public IBindingViewModelOption BindingViewModelOption { get; }
        public IHtmlTag HtmlTag { get; }
        public Attribute Attribute { get; }
        public IHtmlTagAttrId LayoutId { get; }
        public IHtmlTagAttrId LayoutMessageContainerId { get; }
    }
}