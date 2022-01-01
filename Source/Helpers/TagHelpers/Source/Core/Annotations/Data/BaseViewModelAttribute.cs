using System;

using RazorTechnologies.TagHelpers.Core.Common;

namespace RazorTechnologies.TagHelpers.Core.Annotations
{
    public abstract class BaseViewModelAttribute : Attribute, IModelAttribute, IBaseViewModelAttribute
    {
    }
}