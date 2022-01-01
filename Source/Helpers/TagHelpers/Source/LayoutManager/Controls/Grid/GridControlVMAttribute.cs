using System;

using RazorTechnologies.TagHelpers.Core.Annotations;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class GridControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public GridControlVMAttribute()
        {
        }
    }
}