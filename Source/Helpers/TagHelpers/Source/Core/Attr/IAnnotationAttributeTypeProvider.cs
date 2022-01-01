using RazorTechnologies.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.Attr
{
    public interface IAnnotationAttributeTypeProvider
    {
        public Type IgnoreAttributeType { get; }
        public Type DisplayNameAttributeType { get; }
        public Type RequiredAttributeType { get; }
        public Type MaxLengthAttributeType { get; }
        public Type MinLengthAttributeType { get; }
        public Type MaximumLengthAttributeType { get; }
        public Type EmailAddressAttributeType { get; }
        public Type CompareAttributeType { get; }
        public Type RangeFieldAttributeType { get; }
        public Type ComparePasswordAttributeType { get; }
        public Type PasswordAttributeType { get; }
        public Type PhoneAttributeType { get; }
        public Type FormTextFieldAttributeType { get; }
        public Type NumericFieldAttributeType { get; }
        public Type DataViewLableAttributeType { get; }
        public Type ImplicitRequiredAttributeType { get; }
        public Type FormCheckboxFieldAttributeType { get; }
        public Type FormPersianDatePickerFieldAttributeType { get; }
        //??????
        //public Type DocumentUploadControlVMAttributeType { get; }
        //public Type FileUploadControlVMAttributeType { get; }
        //public Type UploadedDocumentControlVMAttributeType { get; }
        //public Type UploadedFileControlVMAttributeType { get; }
        public Type HyperLinkElementAttributeType { get; }
        public bool TryGetAttributes(object targetObject, string propertyName, Type attributeType, bool throwException, out IEnumerable<Attribute> attributes);
        public bool GetPropertyRequired(Type targetType, string propertyName, bool throwException);
        public bool TryGetAttributes<TAttribute>(Type targetType, string propertyName, Type attributeType, bool throwException, out IEnumerable<TAttribute> attributes)
        where TAttribute : Attribute;
        public bool HaveAttribute(SearchMemberMethods method, object targetObject, string propertyName, Type attributeType, bool throwException);

    }
}
