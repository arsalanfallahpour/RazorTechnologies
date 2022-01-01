using System;

namespace RazorTechnologies.TagHelpers.Core.Annotations
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class IgnoredFieldVMAttribute : BaseAnnotationAttribute
    {
    }
}
