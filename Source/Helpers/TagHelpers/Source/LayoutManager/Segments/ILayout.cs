using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;

namespace RazorTechnologies.TagHelpers.LayoutManager.Segments
{
    public interface ILayout
    {
        public LayoutTypes LayoutType { get; }
        public LayoutString GetLayoutString(ILayoutGeneratorOptions options);
    }
}
