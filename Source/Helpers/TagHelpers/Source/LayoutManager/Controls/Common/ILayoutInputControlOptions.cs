using System;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public interface ILayoutInputControlOptions : ILayoutControlOptions, IDisableableHtmlTag
    {
        public IHtmlTagAttrId LayoutFormId { get; }
        public IHtmlTagAttrName LayoutFormName { get; }
        public new IInputHtmlTag HtmlTag { get; }
    }
}