using System;

using RazorTechnologies.TagHelpers.Core.Annotations;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class EmailBoxControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public EmailBoxControlVMAttribute(bool enabled = true)
        {
            Enabled = enabled;
        }
        public bool Enabled { get; private set; }
    }
}
