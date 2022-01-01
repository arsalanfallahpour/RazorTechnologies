using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup;
using System.Collections.Generic;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutBody : IHtmlGeneratable
    {
        public IReadOnlyList<ILayoutScope> Scopes { get; }
    }
}