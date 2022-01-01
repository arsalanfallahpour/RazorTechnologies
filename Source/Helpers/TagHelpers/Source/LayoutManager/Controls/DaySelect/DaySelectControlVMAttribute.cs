using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;

using System;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.DaySelect
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DaySelectControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public DaySelectControlVMAttribute()
        {
        }

    }
}
