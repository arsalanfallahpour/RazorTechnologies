using System.Collections.Generic;

using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup
{
    public interface ILayoutScope
    {
        public bool IsReaddonly { get; }
        public bool Disable { get; }
        public ILayoutScopeGroupHeader Header { get; }
        public ILayoutScopeGroupBody Body { get; }
        public ILayoutScopeGroupFooter Footer { get; }
        public IReadOnlyList<LayoutScopeGroup> ScopeGroups { get; }
        public ILayoutString GetLayoutString(ref LayoutApiDataParameter parameter);
    }
}