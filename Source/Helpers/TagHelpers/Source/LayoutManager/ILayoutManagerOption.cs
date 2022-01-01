using RazorTechnologies.Core.Common;
using System;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutManagerOption
    {
        public BindingApiOption BindingApiOption { get; }
        public TagHelperStates ApiType { get; }
        public Guid Key { get; }
        public HtmlTagAttrId LayoutContainerId { get; }
        public HtmlTagAttrId LayoutFormId { get; }
        public ILayoutGeneratorOutput LayoutGeneratorOutput { get; }
    }
}