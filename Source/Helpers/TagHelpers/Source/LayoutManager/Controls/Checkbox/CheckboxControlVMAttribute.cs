using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using RazorTechnologies.TagHelpers.Core.Annotations;

using static RazorTechnologies.TagHelpers.Core.Attr.AttributeUtilities;
namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class CheckboxControlVMAttribute : BaseViewModelValidationAttribute, IViewModelControlAttribute
    {
        public CheckboxControlVMAttribute(CheckboxApplyMemberCondition applyMemberConditionTo = CheckboxApplyMemberCondition.NoneOfMembers, string toolTip = "")
        {
            ToolTip = toolTip;
            ApplyMemberConditionTo = applyMemberConditionTo;
        }

        public string ToolTip { get; private set; }
        public bool Enabled { get; }
        public string[] DependentMemberNames { get; set; }
        public string[] ReversedDependentMemberNames { get; set; }

        public CheckboxApplyMemberCondition ApplyMemberConditionTo { get; }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var isSucceeded = TryValidateRules(value, out var iValidationResult, out var checkedValue);

            if ((isSucceeded && ApplyMemberConditionTo != CheckboxApplyMemberCondition.AllMembers) || ApplyMemberConditionTo == CheckboxApplyMemberCondition.NoneOfMembers)
                return iValidationResult;


            if (!TryValidateDependentControlRules(checkedValue, validationContext, iValidationResult, out var dependentValidationResult))
                return dependentValidationResult;

            return ValidationResult.Success;
            //var maxSize = 
            //    _maxFileSize > AppWebStaticConfigurations.KestrelMaxRequestBodySize
            //    ? AppWebStaticConfigurations.KestrelMaxRequestBodySize
            //    :  _maxFileSize;
            //if (file != null)
            //    if (file.Length > maxSize)
            //        return new ValidationResult(GetErrorMessage());

            //return ValidationResult.Success;
        }

        private bool TryValidateRules(object value, out ValidationResult iValidationResult, out bool parsedValue)
        {
            parsedValue = false;
            iValidationResult = null;
            if (value is null)
            {
                iValidationResult = new ValidationResult(GetErrorMessage());
                return false;
            }
            if (!bool.TryParse(value.ToString(), out parsedValue))
            {
                iValidationResult = new ValidationResult(GetErrorMessage());
                return false;
            }
            switch (ApplyMemberConditionTo)
            {
                case CheckboxApplyMemberCondition.NoneOfMembers:
                    iValidationResult = ValidationResult.Success;
                    return false;
                case CheckboxApplyMemberCondition.DependentMembers:
                    if (parsedValue)
                    {
                        iValidationResult = ValidationResult.Success;
                        return true;
                    }
                    break;
                case CheckboxApplyMemberCondition.ReverseDependentMembers:
                    if (!parsedValue)
                    {
                        iValidationResult = ValidationResult.Success;
                        return true;
                    }
                    break;
                case CheckboxApplyMemberCondition.AllMembers:
                    return false;
                default:
                    break;
            }
            return false;
        }

        private bool TryValidateDependentControlRules(bool checkedValue, ValidationContext validationContext, ValidationResult defaultResult, out ValidationResult validationResult)
        {
            validationResult = null;
            var messageBuilder = new StringBuilder();
            var errorMembers = new List<string>();
            var isErrorOccured = false;
            var errorContent = string.Empty;
            if (defaultResult is not null)
            {
                messageBuilder.AppendLine($"{defaultResult.ErrorMessage} <br/ >");
                isErrorOccured = true;
            }
            switch (ApplyMemberConditionTo)
            {
                case CheckboxApplyMemberCondition.NoneOfMembers:
                    return true;

                case CheckboxApplyMemberCondition.DependentMembers:
                    if (DependentMemberNames is null)
                        return true;
                    ValidateMember(checkedValue, false, validationContext, DependentMemberNames, ref isErrorOccured, out errorMembers, out errorContent);
                    break;
                case CheckboxApplyMemberCondition.ReverseDependentMembers:
                    if (ReversedDependentMemberNames is null)
                        return true;
                    ValidateMember(checkedValue, false, validationContext, ReversedDependentMemberNames, ref isErrorOccured, out errorMembers, out errorContent);
                    break;
                case CheckboxApplyMemberCondition.AllMembers:
                    if (DependentMemberNames is null || DependentMemberNames.Length < 1
                      || ReversedDependentMemberNames is null || ReversedDependentMemberNames.Length < 1)
                        return true;
                    ValidateMember(checkedValue, false, validationContext, DependentMemberNames, ref isErrorOccured, out errorMembers, out errorContent);
                    ValidateMember(checkedValue, true, validationContext, ReversedDependentMemberNames, ref isErrorOccured, out errorMembers, out string errorContentReversedMembers);
                    errorContent = errorContent.Insert(errorContent.Length == 0 ? 0 : errorContent.Length - 1, errorContentReversedMembers);
                    break;
                default:
                    throw new NotSupportedException(nameof(ApplyMemberConditionTo));
            }
            messageBuilder.Append(errorContent);
            validationResult = new ValidationResult(messageBuilder.ToString());
            return !isErrorOccured;
        }

        private void ValidateMember(bool checkedValue,
                                    bool isReversed,
                                    ValidationContext validationContext,
                                    string[] dependentMemberNames,
                                    ref bool isErrorOccured,
                                    out List<string> errorMembers,
                                    out string errorContent)
        {
            errorMembers = new List<string>();
            var messageBuilder = new StringBuilder();
            for (int d = 0; d < dependentMemberNames.Length; d++)
            {
                var isAdded = false;
                var curentDependentMemberName = dependentMemberNames[d];
                var propValue = GetPropertyValue(validationContext.ObjectInstance, curentDependentMemberName, out var propType);
                if (!TryGetAttributeByInterface<ValidationAttribute>(propType, nameof(ImplicitValidationAttribute), out var attributes))
                    continue;
                for (int i = 0; i < attributes.Count; i++)
                {
                    var curentAttribute = attributes[i];

                    var attributeImplicitInstance = curentAttribute as ImplicitValidationAttribute;
                    attributeImplicitInstance.SetApplyValidation(true);


                    var attributeInstance = curentAttribute as ValidationAttribute;
                    //var errorMessage = attributeInstance.ErrorMessage;
                    var isValid = attributeInstance.IsValid(propValue);
                    if (isReversed && !isValid)
                        continue;
                    else
                        if (isValid)
                        continue;
                    isErrorOccured = true;
                    var result = attributeInstance.GetValidationResult(propValue, validationContext);

                    var displayName = curentDependentMemberName;
                    if (TryGetCustomAttribute<DisplayNameAttribute>(propType, out var displayNameAttributes))
                        displayName = displayNameAttributes.FirstOrDefault().DisplayName;
                    var errorMessage = $" * {displayName} : {result.ErrorMessage}";

                    if (messageBuilder.ToString().Contains(errorMessage))
                        continue;

                    errorMembers.Add(curentDependentMemberName);
                    messageBuilder.AppendLine($"{errorMessage}");
                    isAdded = true;
                }
                if (isAdded)
                    if (d < dependentMemberNames.Length - 1)
                        messageBuilder.AppendLine($" <hr />");
                //var A =  new RequiredAttribute() {ErrorMessageResourceName = string.Empty,ErrorMessage = "Hellow" }.GetValidationResult(propValue, new ValidationContext(validationContext.ObjectInstance));
            }
            errorContent = messageBuilder.ToString();
        }

        public string GetErrorMessage()
        {
            return ErrorMessage;
        }

        public void ValidateMemebers()
        {
            switch (ApplyMemberConditionTo)
            {
                case CheckboxApplyMemberCondition.NoneOfMembers:
                    ThrowForDependentMembers(false);
                    ThrowForReversedDependentMembers(false);
                    break;
                case CheckboxApplyMemberCondition.DependentMembers:
                    ThrowForDependentMembers();
                    ThrowForReversedDependentMembers(false);
                    break;
                case CheckboxApplyMemberCondition.ReverseDependentMembers:
                    ThrowForReversedDependentMembers();
                    ThrowForDependentMembers(false);
                    break;
                case CheckboxApplyMemberCondition.AllMembers:
                    ThrowForDependentMembers();
                    ThrowForReversedDependentMembers();
                    break;
                default:
                    throw new NotSupportedException();
            }

            void ThrowForDependentMembers(bool checkInitialized = true)
            {
                if (checkInitialized)
                {
                    if (DependentMemberNames is null)
                        throw new InvalidOperationException(nameof(DependentMemberNames));
                    if (DependentMemberNames.Length < 1)
                        throw new InvalidOperationException(nameof(DependentMemberNames));
                    return;
                }
                if (DependentMemberNames is not null)
                    throw new InvalidOperationException(nameof(DependentMemberNames));
            }
            void ThrowForReversedDependentMembers(bool checkInitialized = true)
            {
                if (checkInitialized)
                {
                    if (ReversedDependentMemberNames is null)
                        throw new InvalidOperationException(nameof(ReversedDependentMemberNames));
                    if (ReversedDependentMemberNames.Length < 1)
                        throw new InvalidOperationException(nameof(ReversedDependentMemberNames));
                    return;
                }
                if (ReversedDependentMemberNames is not null)
                    throw new InvalidOperationException(nameof(ReversedDependentMemberNames));
            }
        }
    }
    public enum CheckboxApplyMemberCondition
    {
        NoneOfMembers = 0,
        DependentMembers = 1,
        ReverseDependentMembers = 2,
        AllMembers = 3
    }
}