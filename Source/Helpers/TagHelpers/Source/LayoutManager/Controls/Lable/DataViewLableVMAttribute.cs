using System;

using RazorTechnologies.TagHelpers.Core.Annotations;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DataViewLableVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public DataViewLableVMAttribute(string lable, string separator = " : ")
        {
            Lable = lable;
            Separator = separator;
        }

        public string Lable { get; private set; }
        public string Separator { get; private set; }

    }
}
