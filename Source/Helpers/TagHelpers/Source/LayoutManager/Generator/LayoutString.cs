using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.LayoutManager.Generator
{
    public class LayoutString : BaseStringModelValue, ILayoutString
    {

        public LayoutString(string content)
            :base(content)
        {
        }

    }
}
