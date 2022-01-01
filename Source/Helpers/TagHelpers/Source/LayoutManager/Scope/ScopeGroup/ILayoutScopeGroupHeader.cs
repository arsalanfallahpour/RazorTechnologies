using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using System.Collections.Generic;

namespace RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup
{
    public interface ILayoutScopeGroupHeader : IHtmlGeneratable
    {
        public string Title { get;  }
        public string Subtitle { get;  }
        public string Description { get;  }
    }
}