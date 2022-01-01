using System;
using System.Collections.Generic;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public class LayoutManagerOption : ILayoutManagerOption
    {

        public bool BuildOutput(LayoutString layoutString)
        {
            return _layoutGeneratorOutput.BuildRuntime(layoutString);    
        }
        public BindingApiOption BindingApiOption { get; }
        public TagHelperStates ApiType { get; }
        public Guid Key { get; private set; }
        public HtmlTagAttrId LayoutContainerId { get; }
        public HtmlTagAttrId LayoutFormId { get; }

        public ILayoutGeneratorOutput LayoutGeneratorOutput => _layoutGeneratorOutput;

        private readonly LayoutGeneratorOutput _layoutGeneratorOutput;

        public LayoutManagerOption(Guid key,
                                   HtmlTagAttrId layoutContainerId,
                                   HtmlTagAttrId layoutFormId,
                                   LayoutApiSnapshot layoutApiSnapshot,
                                   TagHelperStates apiType,
                                   BindingApiOption bindingApiOption)
        {
            Key = key;
            LayoutContainerId = layoutContainerId;
            LayoutFormId = layoutFormId;
            ApiType = apiType;
            BindingApiOption = bindingApiOption;
            _layoutGeneratorOutput = new(Key, LayoutContainerId, LayoutFormId, layoutApiSnapshot);
        }

        public static bool  operator ==(LayoutManagerOption obj1, LayoutManagerOption obj2) { return obj1.Key.CompareTo(obj2.Key) == 0; }
        public static bool  operator !=(LayoutManagerOption obj1, LayoutManagerOption obj2) { return obj1.Key.CompareTo(obj2.Key) != 0; }
    }
}