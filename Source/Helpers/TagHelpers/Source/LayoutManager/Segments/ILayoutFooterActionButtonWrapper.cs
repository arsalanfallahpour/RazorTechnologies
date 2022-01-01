using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.ViewFeatures;

using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.SubmitButton;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutFooterActionButtonWrapper : IHtmlGeneratable
    {
        public List<ILayoutSubmitButton> ActionButtons { get;}
        public void BuildActionButtons(LayoutTypes layoutType, IHtmlTagAttrId formId);
    }
}