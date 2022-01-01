using Microsoft.AspNetCore.Http;
using RazorTechnologies.TagHelpers.Core.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace RazorTechnologies.TagHelpers.Core.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class AllowedFileExtensionsAttribute : BaseViewModelValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedFileExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                    return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return ErrorMessage;
        }
    }
}
