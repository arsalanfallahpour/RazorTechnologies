using System.Collections;
using System.Collections.Generic;

using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;

namespace RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup
{
    public interface ILayoutScopeGroup
    {
        public ILayoutString GetLayoutString(IEnumerable<ApiDataProperty> groupedProperties);
    }

}