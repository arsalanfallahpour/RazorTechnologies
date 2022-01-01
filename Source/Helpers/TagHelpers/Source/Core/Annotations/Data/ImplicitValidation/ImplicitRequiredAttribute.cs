using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.Annotations
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ImplicitRequiredAttribute : RequiredAttribute, ImplicitValidationAttribute
    {
        //For Non-Nullable Like int <FileUpload> Don't forget ? mark | e.g => int? FileUploadId{ get; set; }
        public ImplicitRequiredAttribute()
        {
            ApplyValdiation = false;
        }
        public bool ApplyValdiation { get; private set; }
        public void SetApplyValidation(bool apply)
            => ApplyValdiation = apply;
        public override bool IsValid(object value)
        {
            if (!ApplyValdiation)
                return true;
            return base.IsValid(value);
        }
    }
}
