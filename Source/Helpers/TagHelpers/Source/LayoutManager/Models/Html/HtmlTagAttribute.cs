using System;

using DotNetCenter.Core;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public abstract class HtmlTagAttribute : BaseStringModelValue, IHtmlTagAttributeMetadata
    {
        public HtmlTagAttribute(string tagContent)
        : base(tagContent)
        { }
        public abstract string AttributeName { get; }
    }
}