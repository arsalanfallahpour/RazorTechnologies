using System;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.Segments;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public interface ILayoutControlOptions
    {
        public IHtmlTagAttrId LayoutId { get; }
        public IHtmlTagAttrId LayoutMessageContainerId { get; }
        public IHtmlTag HtmlTag { get; }
        public TagHelperStates RequestState { get; }
        public IBindingViewModelOption BindingViewModelOption { get; }
        public Attribute Attribute { get; }
    }
}