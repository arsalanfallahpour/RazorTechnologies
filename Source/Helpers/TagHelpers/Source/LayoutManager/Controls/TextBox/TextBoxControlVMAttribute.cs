using System;

using RazorTechnologies.TagHelpers.Core.Annotations;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class TextBoxControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public TextBoxControlVMAttribute(bool enabled = true, bool multiLine = false)
        {
            Enabled = enabled;
            MultiLine = multiLine;
        }
        public bool Enabled { get; private set; }
        public bool MultiLine { get; }
    }
}
