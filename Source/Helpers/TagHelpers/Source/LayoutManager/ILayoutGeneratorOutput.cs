using System;

using Microsoft.AspNetCore.Razor.TagHelpers;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutGeneratorOutput
    {
        public RuntimeLayoutGenerator RuntimeLayoutGenerator { get; }
        public Guid Key { get; }
        public HtmlTagAttrId LayoutContainerId { get; }
        public HtmlTagAttrId LayoutFormId { get; }
        public LayoutApiSnapshot DataBindings { get; }

    }
}