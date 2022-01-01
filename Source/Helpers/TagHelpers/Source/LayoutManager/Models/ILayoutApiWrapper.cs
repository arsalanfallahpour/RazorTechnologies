using System.Collections.Generic;

using RazorTechnologies.TagHelpers.Core.Api;
using RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models
{
    public interface ILayoutApiWrapper : IEnumerable<LayoutApiModel> 
    {
        public IReadOnlyList<LayoutApiModel> LayoutApis { get; }
    }
}