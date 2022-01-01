using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace RazorTechnologies.TagHelpers.Core.Attr
{
    public class AnnotationAttributeTypeProvider : IAnnotationAttributeTypeProvider
    {
        public Type IgnoreAttributeType => typeof(IgnoredFieldVMAttribute);
        public Type DisplayNameAttributeType => typeof(DisplayNameAttribute);
        public Type RequiredAttributeType => typeof(RequiredAttribute);
        public Type MaxLengthAttributeType => typeof(MaxLengthAttribute);
        public Type MinLengthAttributeType => typeof(MinLengthAttribute);
        public Type MaximumLengthAttributeType => typeof(MaxLengthAttribute);
        public Type EmailAddressAttributeType => typeof(EmailAddressAttribute);
        public Type CompareAttributeType => typeof(CompareAttribute);
        public Type RangeFieldAttributeType => typeof(RangeControlVMAttribute);
        public Type ComparePasswordAttributeType => typeof(ComparePasswordBoxControlVMAttribute);
        public Type PasswordAttributeType => typeof(PasswordBoxControlVMAttribute);
        public Type PhoneAttributeType => typeof(PhoneAttribute);
        public Type FormTextFieldAttributeType => typeof(TextBoxControlVMAttribute);
        public Type NumericFieldAttributeType => typeof(NumericBoxControlVMAttribute);
        public Type DataViewLableAttributeType => typeof(DataViewLableVMAttribute);
        public Type ImplicitRequiredAttributeType => typeof(ImplicitRequiredAttribute);
        public Type FormCheckboxFieldAttributeType => typeof(CheckboxControlVMAttribute);
        public Type FormPersianDatePickerFieldAttributeType => typeof(PersianDatePickerControlVMAttribute);
        //????
        //public Type DocumentUploadControlVMAttributeType => typeof(DocumentUploadControlVMAttribute);
        //public Type FileUploadControlVMAttributeType => typeof(FileUploadControlVMAttribute);
        //public Type UploadedDocumentControlVMAttributeType => typeof(UploadedDocumentControlVMAttribute);
        //public Type UploadedFileControlVMAttributeType => typeof(UploadedFileControlVMAttribute);
        public Type HyperLinkElementAttributeType => typeof(HyperLinkControlVMAttribute);

        public static bool TryGetAttributes(Type targetType, string propertyName, Type attributeType, bool throwException, out IEnumerable<Attribute> attributes)
        {
            attributes = null;
            var property = targetType
                           .GetProperty(propertyName);


            bool isPropsNull = property is null;
            if (isPropsNull)
                if (throwException)
                    throw new TargetException($"Property not exist in target type<{targetType.Name}>");

            if (isPropsNull)
                return false;

            attributes = property.GetCustomAttributes(attributeType);

            bool isAttrsNull = attributes is null;
            if (isAttrsNull)
                if (throwException)
                    throw new TargetException($"Attribute not exist in target type<{targetType.Name}>");

            if (isAttrsNull)
                return false;

            return attributes.Any();

        }
        public static bool HaveAttribute(SearchMemberMethods method, Type targetType, string propertyName, Type attributeType, bool throwException)
        {
            var anyAttributes = TryGetAttributes(targetType, propertyName, attributeType, throwException, out var attributes);
            if (!anyAttributes)
                return false;

            if (throwException)
                if (!attributes.Any())
                    throw new TargetException($"Attribute not palaced on target<{propertyName}> property");

            return method switch
            {
                SearchMemberMethods.RootMembers => anyAttributes,
                SearchMemberMethods.InheritedMembers => false,
                _ => throw new NotSupportedException(CommonExceptionMessages.ConditionNotApplied),
            };
        }
        public bool HaveAttribute(SearchMemberMethods method, object targetObject, string propertyName, Type attributeType, bool throwException)
        {
            var anyAttributes = TryGetAttributes(targetObject, propertyName, attributeType, throwException, out var attributes);
            if (!anyAttributes)
                return false;

            if (throwException)
                if (!attributes.Any())
                    throw new TargetException($"Attribute not palaced on target<{propertyName}> property");

            return method switch
            {
                SearchMemberMethods.RootMembers => anyAttributes,
                SearchMemberMethods.InheritedMembers => false,
                _ => throw new NotSupportedException(CommonExceptionMessages.ConditionNotApplied),
            };
        }
        public bool TryGetAttributes<TAttribute>(Type targetType, string propertyName, Type attributeType, bool throwException, out IEnumerable<TAttribute> attributes)
       where TAttribute : Attribute
        {
            attributes = null;
            if (TryGetAttributes(targetType, propertyName, attributeType, throwException, out var attributes1))
            {
                attributes = attributes1.Cast<TAttribute>();
                return true;
            }
            return false;
        }

        public virtual bool GetPropertyRequired(Type targetType, string propertyName, bool throwException)
        {
            var anyAttributes = TryGetAttributes(targetType, propertyName, RequiredAttributeType, true, out var attributes);
            if (!anyAttributes)
            {
                if (throwException)
                    throw new TargetException($"Attribute not palaced on target<{propertyName}> property");
                else
                    return false;
            }

            var isAllow = !(attributes.Cast<RequiredAttribute>()?.ToList()[0]?.AllowEmptyStrings);

            return isAllow ?? false;
        }
        public static string GetPropertyDisplayName(Type targetType, string propertyName)
        {
            var anyAttributes = TryGetAttributes(targetType, propertyName, typeof(DisplayNameAttribute), true, out var attributes);
            if (!anyAttributes)
                throw new TargetException($"Attribute not palaced on target<{propertyName}> property");


            return attributes.Cast<DisplayNameAttribute>()?.ToList()[0]?.DisplayName ?? propertyName;

            #region OtherWay2
            //var attrsList = attrs.ToImmutableList();
            //for (int i = 0; i < attrsList.Count; i++)
            //{
            //    var currentItem = attrsList[i];
            //    var castedObject = currentItem as DisplayNameAttribute;

            //    if (castedObject is not null)
            //    {
            //        var a = castedObject.DisplayName;
            //        return stopWatch.ElapsedMilliseconds;
            //     // return => 0 ms
            //    }
            //}
            #endregion
        }
        public bool TryGetAttributes(object targetObject, string propertyName, Type attributeType, bool throwException, out IEnumerable<Attribute> attributes)
        {
            attributes = null;

            var property = TypeDescriptor.GetProperties(targetObject, false).Find(propertyName, false);


            bool isPropsNull = property is null;
            if (isPropsNull)
                if (throwException)
                    throw new TargetException($"Property not exist in target type<{targetObject.GetType().FullName}>");

            if (isPropsNull)
                return false;

            attributes = property.Attributes.OfType<Attribute>();

            bool isAttrsNull = attributes is null;
            if (isAttrsNull)
                if (throwException)
                    throw new TargetException($"Attribute not exist in target type<{targetObject.GetType().FullName}>");

            if (isAttrsNull)
                return false;

            return attributes.Any();
            //bool isPropsNull = property is null;
            //if (isPropsNull)
            //    if (throwException)
            //        throw new TargetException($"Property not exist in target type<{targetType.Name}>");

            //if (isPropsNull)
            //    return false;
            //var enumerator = property.Attributes.GetEnumerator();
            //var isAttrsNull = true;
            //while (enumerator.MoveNext())
            //{
            //    var current = (enumerator.Current as DefaultMemberAttribute)?.TypeId as Type;
            //    if (current is null)
            //        continue;
            //    if (current.GUID.CompareTo(attributeType.GUID) == 0)
            //        continue;
            //    isAttrsNull = false;
            //    attributes.Add((enumerator.Current as DefaultMemberAttribute).TypeId as Attribute);
            //}

            //if (isAttrsNull)
            //    if (throwException)
            //        throw new TargetException($"Attribute not exist in target type<{targetType.Name}>");

            //if (isAttrsNull)
            //    return false;

        }
    }
}
