using System;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public class LayoutCollectionControlOptions : ILayoutControlOptions
    {

        public LayoutCollectionControlOptions(IBindingViewModelOption bindingViewModelOption,
            TagHelperStates formState)
        {
            if(string.IsNullOrEmpty(bindingViewModelOption.BindingModelName))
                throw new System.ArgumentException(nameof(BindingViewModelOption.BindingModelName));

            RequestState = formState;
            BindingViewModelOption = bindingViewModelOption;
        }
        public TagHelperStates RequestState { get; }
        public IBindingViewModelOption BindingViewModelOption { get; }
        public IHtmlTag HtmlTag => throw new System.NotImplementedException();
        public Attribute Attribute { get; }
        public IHtmlTagAttrId LayoutId { get; }
        public IHtmlTagAttrId LayoutMessageContainerId { get; }
    }
}