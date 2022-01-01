using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RazorTechnologies.TagHelpers.Core.Annotations
{
    public abstract class BaseViewModelValidationAttribute : BaseValidationAttribute, IBaseViewModelAttribute
    {
        public static object GetPropertyValue(object src, string propName, out PropertyInfo propertyInfo)
        {
            propertyInfo = GetPropertyInfo(src, propName);
            return propertyInfo.GetValue(src, null);
        }

        private static PropertyInfo GetPropertyInfo(object src, string propName)
        {
            return src.GetType().GetProperty(propName) ?? throw new NullReferenceException();
        }

    }
}