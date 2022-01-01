using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls
{
    public interface ILayoutHeaderData : IHtmlTag
    {
        public string Title { get; }
        public string SubTitle { get; }
        public string Description { get; }
        public IReadOnlyCollection<IBindingViewModelMemberOption> Data { get; }

        public bool HasData() => Data.Count > 0;
    }

    public enum HeaderDataRoles
    {
        DisplayData = 0,
        FormData = 1
    }
}