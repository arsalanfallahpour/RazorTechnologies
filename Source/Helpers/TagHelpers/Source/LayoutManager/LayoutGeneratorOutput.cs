using System;
using System.Collections.Generic;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public class LayoutGeneratorOutput : ILayoutGeneratorOutput
{

        public LayoutGeneratorOutput(Guid key, HtmlTagAttrId layoutContainerId, HtmlTagAttrId layoutFormId, LayoutApiSnapshot _dataBindings)
        {
            Key = key;
            LayoutContainerId = layoutContainerId;
            LayoutFormId = layoutFormId;
            DataBindings= _dataBindings;
        }

        public bool BuildRuntime(LayoutString layoutString) {
            RuntimeLayoutGenerator.MakeReadyToPresent(layoutString);
            return RuntimeLayoutGenerator is null && RuntimeLayoutGenerator.IsReadyToPresent;
        }
        public RuntimeLayoutGenerator RuntimeLayoutGenerator { get; } = new();
        public Guid Key { get; }
        public HtmlTagAttrId LayoutContainerId { get; }
        public HtmlTagAttrId LayoutFormId { get; }
        public LayoutApiSnapshot DataBindings { get; }

    }
}