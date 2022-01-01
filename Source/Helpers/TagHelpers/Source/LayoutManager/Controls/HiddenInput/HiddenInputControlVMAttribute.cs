using System;

using RazorTechnologies.TagHelpers.Core.Annotations;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class HiddenInputControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public HiddenInputControlVMAttribute()
        {
        }
    }
}
