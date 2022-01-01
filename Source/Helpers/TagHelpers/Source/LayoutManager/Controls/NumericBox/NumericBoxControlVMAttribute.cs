using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class NumericBoxControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public NumericBoxControlVMAttribute(int minValue = 0, long maxValue = 100 , int step = 1, string placeholder = "", bool enabled = true)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Step = step;
            Placeholder = placeholder;
            Width = (MaxValue.ToString().Length * 5);
            Enabled = enabled;
        }
        public int Width { get; }
        public int MinValue { get; }
        public long MaxValue { get; }
        public int Step { get; }
        public string Placeholder { get; }
        public bool Enabled { get; private set; }
    }
}
