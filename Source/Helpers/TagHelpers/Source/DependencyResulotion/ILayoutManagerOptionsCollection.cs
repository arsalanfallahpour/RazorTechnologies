using RazorTechnologies.TagHelpers.LayoutManager;

using System;
using System.Collections.Generic;

namespace RazorTechnologies.TagHelpers.DependencyResulotion
{
    public interface ILayoutManagerOptionsCollection : IReadOnlyCollection<LayoutManagerOption>
    {
        public bool TryGetOptions(Guid key, out LayoutManagerOption options);
    }
}