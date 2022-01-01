using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;

using System;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.MonthSelect
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class MonthSelectControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public MonthSelectControlVMAttribute()
        {
        }

    }
}
