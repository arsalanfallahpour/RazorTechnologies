using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RazorTechnologies.TagHelpers.Core.Annotations;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class RangeControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public RangeControlVMAttribute(int minValue = 0, int maxValue = 100 , int step = 1, string placeholder = "")
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Step = step;
            Placeholder = placeholder;
        }
        public int MinValue { get; }
        public int MaxValue { get; }
        public int Step { get; }
        public string Placeholder { get; }
    }
}
