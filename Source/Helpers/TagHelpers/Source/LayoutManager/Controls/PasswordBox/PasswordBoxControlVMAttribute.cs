using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class PasswordBoxControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public char PasswordChar => '*';
    }
}
