using Microsoft.AspNetCore.Http;
using RazorTechnologies.TagHelpers.Core.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace RazorTechnologies.TagHelpers.Core.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MaxFileSizeAttribute : BaseViewModelValidationAttribute
    {
        private readonly int _maxFileSize;
        // _maxFileSize e.g. _maxFileSize = AppWebStaticConfigurations.KestrelMaxRequestBodySize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
                if (file.Length > _maxFileSize)
                    return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return ErrorMessage;
        }
    }
}
