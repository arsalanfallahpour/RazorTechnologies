namespace RazorTechnologies.TagHelpers.Core
{
    using System;
    using System.Collections.Generic;
using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
    using RazorTechnologies.Core.Common;
    using RazorTechnologies.TagHelpers.Core.THelper;
    using RazorTechnologies.TagHelpers.LayoutManager;
    using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
    public abstract class BaseFormRequestTagHelper<TRequestViewModel>
        : BaseRequestTagHelper, IFormRequestTagHelper
        where TRequestViewModel : BaseAppRequestViewModel
    {
        public BaseFormRequestTagHelper(ILayoutManager layoutManager)
            : base(layoutManager)
        {
            //ApplyAdditionalAttributes(RequestViewModel, RequestViewModelType);

            if (RequestViewModelType is null)
                throw new ArgumentNullException();

            //_filtredRequestViewModelProperties = AllViewModelProperties.Where(o =>
            //!annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, annotationAttributeType.IgnoreAttributeType, false)
            //&& !annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, annotationAttributeType.DataViewLableAttributeType, false)
            ////&& !annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AppHyperLinkElementAttributeType, false)
            //).ToArray();

            ////_rangeRequestViewModelProperties = _allRequestViewModelProperties.Where(o => !annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, RangeAttributeType, false)).ToArray();
            //_emailAddressRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.RangeFieldAttributeType, false)).ToArray();
            //_comparePasswordRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.ComparePasswordAttributeType, false)).ToArray();
            //_passwordRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.PasswordAttributeType, false)).ToArray();
            //_compareRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.CompareAttributeType, false)).ToArray();
            //_textRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.FormTextFieldAttributeType, false)).ToArray();
            //_phoneNumberRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.PhoneAttributeType, false)).ToArray();
            //_requiredRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.RequiredAttributeType, false)).ToArray();
            //_citySelectRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.FormCitySelectType, false)).ToArray();
            //_numericInputRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.NumericFieldAttributeType, false)).ToArray();
            //_dataViewRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.DataViewLableAttributeType, false)).ToArray();
            //_checkboxRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.FormCheckboxFieldAttributeType, false)).ToArray();
            //_persianDatePickerRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.FormPersianDatePickerFieldAttributeType, false)).ToArray();
            //_generatedTypeSelectRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.FormGeneratedTypeSelectFieldAttributeType, false)).ToArray();

            //????
            //_fileUploadRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.FileUploadControlVMAttributeType, false)).ToArray();
            //_uploadedFileRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.UploadedFileControlVMAttributeType, false)).ToArray();
            //_documentUploadRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.DocumentUploadControlVMAttributeType, false)).ToArray();
            //_uploadedDocumentRequestViewModelProperties = AllViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AttributeTypeProvider.UploadedDocumentControlVMAttributeType, false)).ToArray();

            //_hyperLinkRequestViewModelProperties = _allRequestViewModelProperties.Where(o => annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, AppHyperLinkElementAttributeType, false)).ToArray();
            //AllRequestViewModelPropertyNames = AllViewModelProperties.AsEnumerable<PropertyInfo>().Select(o => o.Name).ToList();
            //FiltredRequestViewModelPropertyNames = _filtredRequestViewModelProperties.AsEnumerable<PropertyInfo>().Select(o => o.Name).ToList();

            //FormRequestViewModelProperties = AllViewModelProperties.Where(o =>
            //!annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, annotationAttributeType.IgnoreAttributeType, false)).ToArray();
            //FormRequestViewModelPropertyNames = FormRequestViewModelProperties.AsEnumerable<PropertyInfo>().Select(o => o.Name).ToList();
            //_selectRequestViewModelProperties = _allRequestViewModelProperties.Where(o => !annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, RangeAttributeType, false)).ToArray();
            //_imageContentViewModelProperties = _allRequestViewModelProperties.Where(o => !annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, RangeAttributeType, false)).ToArray();
            //_imageAddressViewModelProperties = _allRequestViewModelProperties.Where(o => !annotationAttributeType.HaveAttribute(SearchMemberMethods.RootMembers, RequestViewModelType, o.Name, RangeAttributeType, false)).ToArray();


            if (RequestViewModelType is null)
                throw new TargetException("RequestViewModel type has no property");


        }
        public virtual string RequestFormId => $"{RequestViewModelName.ToLower()}-form";
        public virtual string AlternateFormsWrapperId => $"{RequestFormId}_AlternateFormWrapperId";
        //ViewModel Guid 
        //ViewModelProperty Name
        public abstract JsBindedModelValues JsBindedModelValues { get; set; }
        public abstract string ReturnUrl { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var layout = LayoutManager.GetLayoutString();
            var sb = new StringBuilder();
                sb.Append("<script>");
                sb.Append($"var redirectUri{LayoutManager.Options.LayoutFormId} = \'null\';");
                sb.Append("$(document).ready(function(){ ");
            //sb.Append($"document.getElementById('sid_{LayoutManager.Options.LayoutFormId}').innerText = '{SubmitButtonText}';" );
            sb.Append($"$('#sid_{LayoutManager.Options.LayoutFormId}').text('{SubmitButtonText}');");
            if (!string.IsNullOrEmpty(ReturnUrl))
            sb.Append($"redirectUri{LayoutManager.Options.LayoutFormId} = \'{ReturnUrl}\';");
            sb.Append(" });");
                sb.Append("</script>");
            sb.Append(layout.Content);
            sb.Append(RenderJsBindedModelValuesScript());
            output.Content.SetHtmlContent(sb.ToString());
            return base.ProcessAsync(context, output);
        }

        private string RenderJsBindedModelValuesScript()
        {
            if (JsBindedModelValues is null || JsBindedModelValues.Count < 1)
                return string.Empty;

            var sb = new StringBuilder();   
            sb.Append("<script> $(document).ready(function(){");
            var enumJsBindedModelValues = JsBindedModelValues.GetEnumerator();
            while (enumJsBindedModelValues.MoveNext())
            {
                var current = enumJsBindedModelValues.Current;
                // TODO ApiSnapShotModelId
                var parameter = LayoutManager.Options.LayoutGeneratorOutput?.DataBindings
                    ?.Where(o => o?.ApiParameterRquestViewModelType?.GUID.CompareTo(current.ViewModelTypeGuid) == 0)?.FirstOrDefault();
                if (parameter is null)
                    continue;

                var property= parameter
                    ?.FirstOrDefault(o => o?.Name == current.PropertyName);

                if (property is null)
                    continue;
                sb.Append($"let jqVar_dv_{property.UiControlId}_as = $('#{property.UiControlId}');");
                switch (property.LayoutControlType.TypedValue)
                {
                    case LayoutControlTypes.TextBox:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case LayoutControlTypes.EmailBox:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case LayoutControlTypes.PhoneNumberBox:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case LayoutControlTypes.CheckBox:
                        if (!bool.TryParse(current.PropertyValue, out var @checked))
                            throw new Exception("Wrong value passed into model");
                        var value = @checked ? "true" : "false";
                        //sb.Append($"$('#{property.UiControlId}').prop('checked','{value}');");
                        sb.Append($"let isChecked_{property.UiControlId} = jqVar_dv_{property.UiControlId}_as.prop('checked');");
                        sb.Append($"if(isChecked_{property.UiControlId} === false && {@checked.ToString().ToLower()} == true){{");
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.click();");
                        sb.Append('}');
                        //sb.Append($"$('#{property.UiControlId}').attr('checked','{value}');");
                        break;
                    case LayoutControlTypes.NumericBox:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case LayoutControlTypes.PersianDatePicker:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case LayoutControlTypes.Range:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case LayoutControlTypes.PasswordBox:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case LayoutControlTypes.ComparePasswordBox:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case LayoutControlTypes.DataViewLable:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    case LayoutControlTypes.HiddenInput:
                        sb.Append($"jqVar_dv_{property.UiControlId}_as.val('{current.PropertyValue}');");
                        break;
                    default:
                            throw new Exception("Unkown Controls cannot accept Value from ui");
                }
                sb.Append($"jqVar_dv_{property.UiControlId}_as.prop('disabled', true);");

            }

            sb.Append("});</script>");
            return sb.ToString();
        }

        //private void ApplyAdditionalAttributes(object instance, Type type, PropertyInfo[] props)
        //{
        //    PropertyOverridingTypeDescriptor ctd = new PropertyOverridingTypeDescriptor(TypeDescriptor.GetProvider(instance).GetTypeDescriptor(instance));
        //    foreach (var prop in props)
        //    {
        //        var attrs = prop.GetCustomAttributes<FileBrowserVMAttribute>(true).ToList()[0].GetAdditionalAttributes();
        //        PropertyDescriptor pd2 =
        //            TypeDescriptor.CreateProperty(
        //                type, // or just _settings, if it's already a type
        //                TypeDescriptor.GetProperties(instance)[prop.Name],
        //                attrs.ToArray()
        //         );
        //        ctd.OverrideProperty(pd2);
        //    }
        //    TypeDescriptor.AddProvider(new TypeDescriptorOverridingProvider(ctd), instance);
        //    var props2 = TypeDescriptor.GetProperties(instance, true);

        //}
        //private void ApplyAdditionalAttributes(object instance, Type type)
        //{
        //    PropertyOverridingTypeDescriptor ctd = new PropertyOverridingTypeDescriptor(TypeDescriptor.GetProvider(instance).GetTypeDescriptor(instance));
        //    foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(instance))
        //    {
        //        var prop = type.GetProperties().FirstOrDefault(o => o.Name == pd.Name);
        //        var attrs = prop.GetCustomAttributes<BaseFormControlViewModelAttribute>(true).ToList();

        //        if (!attrs.Any())
        //            continue;

        //        var additionalAttributes = new List<Attribute>();
        //        for (int i = 0; i < attrs.Count; i++)
        //            additionalAttributes.AddRange(attrs[i].GetAdditionalAttributes());

        //        PropertyDescriptor pd2 =
        //            TypeDescriptor.CreateProperty(
        //                type, // or just _settings, if it's already a type
        //                pd,
        //                additionalAttributes.ToArray()
        //         );
        //        ctd.OverrideProperty(pd2);
        //    }
        //    TypeDescriptor.AddProvider(new TypeDescriptorOverridingProvider(ctd), instance);
        //    var props2 = TypeDescriptor.GetProperties(instance, true);

        //}

        //All Fields
        #region Properties Fields

        public virtual string RequestViewModelName => RequestViewModelType.Name;
        public override string TargetRequestModelTargetBindingArgumentName => RequestViewModelName;
        public virtual Type RequestViewModelType => typeof(TRequestViewModel);
        //public IList<string> AllRequestViewModelPropertyNames { get; private set; }
        //All Fields Except Ignored and DataView

        //public IList<string> FiltredRequestViewModelPropertyNames { get; private set; }
        ////All Fields Except Ignored
        //public virtual PropertyInfo[] FormRequestViewModelProperties { get; private set; }
        //public IList<string> FormRequestViewModelPropertyNames { get; private set; }

        //public virtual PropertyInfo[] FiltredRequestViewModelProperties => _filtredRequestViewModelProperties;
        //private readonly PropertyInfo[] _filtredRequestViewModelProperties;

        //public virtual PropertyInfo[] RangeRequestViewModelProperties => _rangeRequestViewModelProperties;
        //private readonly PropertyInfo[] _rangeRequestViewModelProperties;

        //public virtual PropertyInfo[] SelectRequestViewModelProperties => _rangeRequestViewModelProperties;
        //private readonly PropertyInfo[] _selectRequestViewModelProperties;

        //public virtual PropertyInfo[] MultiColumnSelectRequestViewModelProperties => _multiColumnSelectRequestViewModelProperties;
        //private readonly PropertyInfo[] _multiColumnSelectRequestViewModelProperties;

        //public virtual PropertyInfo[] CheckboxRequestViewModelProperties => _checkboxRequestViewModelProperties;
        //private readonly PropertyInfo[] _checkboxRequestViewModelProperties;

        //public virtual PropertyInfo[] DataLableRequestViewModelProperties => _dataViewRequestViewModelProperties;
        //private readonly PropertyInfo[] _dataViewRequestViewModelProperties;


        //public virtual PropertyInfo[] EmailAddressRequestViewModelProperties => _emailAddressRequestViewModelProperties;
        //private readonly PropertyInfo[] _emailAddressRequestViewModelProperties;
        //private readonly PropertyInfo[] _compareRequestViewModelProperties;
        //private readonly PropertyInfo[] _comparePasswordRequestViewModelProperties;
        //private readonly PropertyInfo[] _passwordRequestViewModelProperties;
        //private readonly PropertyInfo[] _citySelectRequestViewModelProperties;
        //private readonly PropertyInfo[] _numericInputRequestViewModelProperties;
        //private readonly PropertyInfo[] _hyperLinkRequestViewModelProperties;
        //private readonly PropertyInfo[] _persianDatePickerRequestViewModelProperties;
        //private readonly PropertyInfo[] _generatedTypeSelectRequestViewModelProperties;
        //private readonly PropertyInfo[] _fileUploadRequestViewModelProperties;
        //private readonly PropertyInfo[] _uploadedFileRequestViewModelProperties;
        //private readonly PropertyInfo[] _documentUploadRequestViewModelProperties;
        //private readonly PropertyInfo[] _uploadedDocumentRequestViewModelProperties;

        //public virtual PropertyInfo[] PhoneNumberRequestViewModelProperties => _phoneNumberRequestViewModelProperties;
        //private readonly PropertyInfo[] _phoneNumberRequestViewModelProperties;

        //public virtual PropertyInfo[] RequiredRequestViewModelProperties => _requiredRequestViewModelProperties;
        //private readonly PropertyInfo[] _requiredRequestViewModelProperties;

        //public virtual PropertyInfo[] ImageContentViewModelProperties => _rangeRequestViewModelProperties;
        //private readonly PropertyInfo[] _imageContentViewModelProperties;
        //public virtual PropertyInfo[] ImageAddressViewModelProperties => _rangeRequestViewModelProperties;
        //private readonly PropertyInfo[] _imageAddressViewModelProperties;
        //public virtual PropertyInfo[] TextRequestViewModelProperties => _rangeRequestViewModelProperties;
        //private readonly PropertyInfo[] _textRequestViewModelProperties;
        public virtual string OnSubmitButtonScript => "";
        #endregion


        //public string GetHtmlFormTagName(string modelPropName)
        //    => GetHtmlFormTagName(modelPropName, TagHelperTargetBindingArgumentType);

        //public virtual bool IsRequiredRequestModelProperty(string propertyName)
        //    => AttributeTypeProvider.GetPropertyRequired(RequestViewModelType, propertyName, false);
        //protected string RenderHtmlFormHeaderDataViewFields(IDictionary<string, string> headerDataViewFields)
        //{
        //    if (headerDataViewFields is null)
        //        return string.Empty;

        //    if (headerDataViewFields.Count < 1)
        //        return string.Empty;
        //    var sb = new StringBuilder();

        //    for (int i = 0; i < headerDataViewFields.Keys.Count; i++)
        //    {
        //        var currentKey = headerDataViewFields.Keys.ElementAt(i);
        //        var cuid = CuidGenerator.NewCuid();
        //        if (!AttributeTypeProvider.TryGetAttributes<DataViewLableVMAttribute>(RequestViewModelType, currentKey, AttributeTypeProvider.DataViewLableAttributeType, true, out var attributes))
        //            continue;
        //        var html = GetHtmlRequestFormFieldContent(GetFieldType(RequestViewModelType, currentKey),
        //            RequestViewModelType, currentKey, cuid, cuid, GetHtmlFormTagName(currentKey), attributes.FirstOrDefault().Lable
        //            , true, true, headerDataViewFields[currentKey]);
        //        sb.Append(html);
        //    }
        //    //var sb = new StringBuilder();
        //    //sb.Append($"<div class='my-2 py-1'>");
        //    //for (int i = 0; i < headerDataViewFields.Keys.Count; i++)
        //    //{
        //    //    var currentKey = headerDataViewFields.Keys.ElementAt(i);
        //    //    if (!AttributeTypeProvider.TryGetAttributes<DataViewLableVMAttribute>(RequestViewModelType, currentKey, FormDataViewAttributeType, true, out var attributes))
        //    //        continue;
        //    //    var separator = attributes?.FirstOrDefault()?.Separator ?? ":";
        //    //    var lable = attributes?.FirstOrDefault()?.Lable;
        //    //    string uniqueId = $"as{CuidGenerator.NewCuid()}";
        //    //    sb.Append(GetHtmlRequestFormLableFieldContent(currentKey, headerDataViewFields[currentKey], uniqueId, uniqueId, GetHtmlFormTagName(currentKey), lable, separator));
        //    //}
        //    //sb.Append($"</div>");
        //    return sb.ToString();
        //}
        protected string GetHtmlRequestFormFieldContent(LayoutControlTypes fieldType, Type targetType, string propertyName, string tagUniqueId, string tagId, string tagName, string lable, bool required, bool disabled = false, string initialValue = "")
        {
            IEnumerable<Attribute> attributes;
            switch (fieldType)
            {
                //case ModelFieldTypes.Text:
                //    return GetHtmlRequestFormTextFieldContent(tagUniqueId, tagId, tagName, lable, required, disabled, initialValue);
                ////case ModelFieldTypes.HyperLink:
                ////    AttributeTypeProvider.TryGetAttributes(propertyName, AppHyperLinkElementAttributeType, true, out attributes);
                ////    var hyperLinkattribute = attributes.Cast<AppHyperLinkElementAttribute>().ToArray()[0];
                ////return GetHtmlRequestFormHyperLinkContent(tagUniqueId, tagId, tagName, lable, hyperLinkattribute.Href, hyperLinkattribute.Text, hyperLinkattribute.Target);
                //case ModelFieldTypes.DataViewField:
                //    throw new Exception($"{tagName} model field must have one {nameof(DataViewLableVMAttribute)} and one of UiControlAttribute eg. [TextControlVM]");
                //case ModelFieldTypes.Email:
                //    return GetHtmlRequestFormTextFieldContent(tagUniqueId, tagId, tagName, lable, required, disabled, initialValue);
                //case ModelFieldTypes.ImageAddress:
                //    return GetHtmlRequestFormTextFieldContent(tagUniqueId, tagId, tagName, lable, required, disabled, initialValue);
                //case ModelFieldTypes.Select:
                //    return GetHtmlRequestFormTextFieldContent(tagUniqueId, tagId, tagName, lable, required, disabled, initialValue);
                //case ModelFieldTypes.GeneratedTypeSelect:
                //    TryGetAttributes(propertyName, AttributeTypeProvider.FormGeneratedTypeSelectFieldAttributeType, true, out attributes);
                //    var generatedTypeAttribute = attributes.Cast<GeneratedTypeSelectVMAttribute>().ToArray()[0];
                //    var generatedTypeTask = GetHtmlRequestFormGeneratedTypeSelectFieldContent(tagUniqueId, tagId, tagName, lable, disabled, generatedTypeAttribute);
                //    return generatedTypeTask.Result;
                //case ModelFieldTypes.FileUpload:
                //    TryGetAttributes(propertyName, AttributeTypeProvider.FileUploadControlVMAttributeType, true, out attributes);
                //    var fileUploadAttribute = attributes.Cast<FileUploadControlVMAttribute>().ToArray()[0];
                //    TryGetAttributes(propertyName, AttributeTypeProvider.UploadedFileControlVMAttributeType, true, out attributes);
                //    var uploadedFileAttribute = attributes.Cast<UploadedFileControlVMAttribute>().ToArray()[0];
                //    return GetHtmlRequestFormFileUploadContent(propertyName, tagUniqueId, tagId, tagName, lable, fileUploadAttribute, uploadedFileAttribute);
                //case ModelFieldTypes.DocumentUpload:
                //    TryGetAttributes(propertyName, AttributeTypeProvider.DocumentUploadControlVMAttributeType, true, out attributes);
                //    var documentUploadAttribute = attributes.Cast<DocumentUploadControlVMAttribute>().ToArray()[0];
                //    TryGetAttributes(propertyName, AttributeTypeProvider.UploadedDocumentControlVMAttributeType, true, out attributes);
                //    var uploadedDocumentAttribute = attributes.Cast<UploadedDocumentControlVMAttribute>().ToArray()[0];
                //    return GetHtmlRequestFormDocumentUploadContent(tagUniqueId, tagId, tagName, lable, documentUploadAttribute, uploadedDocumentAttribute);
                //case ModelFieldTypes.PersianDatePicker:
                //    TryGetAttributes(propertyName, AttributeTypeProvider.FormPersianDatePickerFieldAttributeType, true, out attributes);
                //    var persianDatePickerAttribute = attributes.Cast<PersianDatePickerControlVMAttribute>().ToArray()[0];
                //    return GetHtmlRequestFormPersianDatePickerContent(tagUniqueId, tagId, tagName, lable, disabled, persianDatePickerAttribute);
                //case ModelFieldTypes.Checkbox:
                //    TryGetAttributes(propertyName, AttributeTypeProvider.FormCheckboxFieldAttributeType, true, out attributes);
                //    var checkboxAttribute = attributes.Cast<CheckboxControlVMAttribute>().ToArray()[0];
                //    if (!bool.TryParse(initialValue, out var isChecked))
                //        isChecked = false;
                //    return GetHtmlRequestFormCheckboxContent(tagUniqueId, tagId, tagName, lable, disabled, isChecked, checkboxAttribute);
                //case ModelFieldTypes.RadioButton:
                //    return GetHtmlRequestFormTextFieldContent(tagUniqueId, tagId, tagName, lable, required, disabled, initialValue);
                //case ModelFieldTypes.Range:
                //    return GetHtmlRequestFormRangeFieldContent(tagUniqueId, tagId, tagName, lable, required, disabled, initialValue);
                //case ModelFieldTypes.Phone:
                //    return GetHtmlRequestFormTextFieldContent(tagUniqueId, tagId, tagName, lable, required, disabled, initialValue);
                //case ModelFieldTypes.Ignored:
                //    return string.Empty;
                //case ModelFieldTypes.ComparePassword:
                //    return GetHtmlRequestFormPasswordFieldContent(tagUniqueId, tagId, tagName, lable, required);
                //case ModelFieldTypes.Compare:
                //    return GetHtmlRequestFormTextFieldContent(tagUniqueId, tagId, tagName, lable, required, disabled, initialValue);
                //case ModelFieldTypes.Password:
                //    return GetHtmlRequestFormPasswordFieldContent(tagUniqueId, tagId, tagName, lable, required);
                //case ModelFieldTypes.CitySelect:
                //    var citySelectTask = GetHtmlRequestFormCitySelectFieldContent(tagUniqueId, tagId, tagName, lable, required);
                //    return citySelectTask.Result;
                //case ModelFieldTypes.NumericInput:
                //    TryGetAttributes(propertyName, AttributeTypeProvider.NumericFieldAttributeType, true, out attributes);
                //    var numericFieldAttribute = attributes.Cast<NumericControlVMAttribute>().ToArray()[0];
                //    return GetHtmlRequestFormNumericInputFieldContent(tagUniqueId, tagId, tagName, lable, disabled, initialValue, numericFieldAttribute);
                default:
                    throw new NotSupportedException("Condition not applied");
            }
        }
        //public virtual string GetRequestModelPropertyTitle(string propertyName)
        //    => AnnotationAttributeTypeProvider.GetPropertyDisplayName(RequestViewModelType, propertyName);
        //protected string GetHtmlRequestFormFieldContent(Type modelFiledType, string propertyName, string tagUniqueId, string tagId, string tagName, string lable, bool required, bool disabled = false, string initialValue = "")
        //    => GetHtmlRequestFormFieldContent(GetFieldType(modelFiledType), modelFiledType, propertyName, tagUniqueId, tagId, tagName, lable, required, disabled, initialValue);
        //protected bool TryGetAttributes(string propertyName, Type attributeType, bool throwException, out IEnumerable<Attribute> attributes)
        //=> AttributeTypeProvider.TryGetAttributes(RequestViewModelType, propertyName, attributeType, throwException, out attributes);
        //protected bool TryGetAttributes2(string propertyName, Type attributeType, bool throwException, out IEnumerable<Attribute> attributes)
        // => AttributeTypeProvider.TryGetAttributes(RequestViewModelType, propertyName, attributeType, throwException, out attributes);

        //protected string GetHtmlFormTagName(string modelPropName, TargetBindingArgumentTypes tagHelperTargetBindingArgument)
        //{
        //    var fieldName = TargetRequestModelTargetBindingArgumentName + '.' + modelPropName;
        //    if (TargetBindingArgumentTypes.IndividualFields == tagHelperTargetBindingArgument)
        //        fieldName = modelPropName;
        //    return fieldName;
        //}
        //protected ModelFieldTypes GetFieldType(Type targetType, string targetPropertyName)
        //{
        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.IgnoreAttributeType, false, out var attributes))
        //        return ModelFieldTypes.Ignored;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.FormTextFieldAttributeType, false, out attributes))
        //        return ModelFieldTypes.Text;

        //    //if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AppHyperLinkElementAttributeType, false, out attributes))
        //    //    return ModelFieldTypes.HyperLink;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.FormPersianDatePickerFieldAttributeType, false, out attributes))
        //        return ModelFieldTypes.PersianDatePicker;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.FormCheckboxFieldAttributeType, false, out attributes))
        //        return ModelFieldTypes.Checkbox;
        //    //????
        //    //if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.DocumentUploadControlVMAttributeType, false, out attributes))
        //    //    return ModelFieldTypes.DocumentUpload;

        //    //if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.UploadedDocumentControlVMAttributeType, false, out attributes))
        //    //    return ModelFieldTypes.UploadedDocument;

        //    //if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.FileUploadControlVMAttributeType, false, out attributes))
        //    //    return ModelFieldTypes.FileUpload;

        //    //if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.UploadedFileControlVMAttributeType, false, out attributes))
        //    //    return ModelFieldTypes.UploadedFile;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.EmailAddressAttributeType, false, out attributes))
        //        return ModelFieldTypes.Email;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.RangeFieldAttributeType, false, out attributes))
        //        return ModelFieldTypes.Range;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.PhoneAttributeType, false, out attributes))
        //        return ModelFieldTypes.Phone;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.ComparePasswordAttributeType, false, out attributes))
        //        return ModelFieldTypes.ComparePassword;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.CompareAttributeType, false, out attributes))
        //        return ModelFieldTypes.Compare;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.PasswordAttributeType, false, out attributes))
        //        return ModelFieldTypes.Password;


        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.DataViewLableAttributeType, false, out attributes))
        //        return ModelFieldTypes.DataViewField;

        //    if (AttributeTypeProvider.TryGetAttributes(targetType, targetPropertyName, AttributeTypeProvider.NumericFieldAttributeType, false, out attributes))
        //        return ModelFieldTypes.NumericInput;

        //    return ModelFieldTypes.Unkown;
        //}
        //protected ModelFieldTypes GetFieldType(Type targetPropertyType)
        //{
        //    var finded = TextRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.Text;

        //    //finded = _hyperLinkRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    //if (finded is not null)
        //    //    return ModelFieldTypes.HyperLink;


        //    finded = _persianDatePickerRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.PersianDatePicker;

        //    finded = _checkboxRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.Checkbox;


        //    finded = _generatedTypeSelectRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.GeneratedTypeSelect;

        //    //finded = SelectRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    //if (finded is not null)
        //    //    return ModelFieldTypes.Select;

        //    finded = _comparePasswordRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.ComparePassword;

        //    finded = _compareRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.Compare;


        //    finded = _fileUploadRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.FileUpload;

        //    finded = _documentUploadRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.DocumentUpload;


        //    finded = _uploadedDocumentRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.UploadedDocument;

        //    finded = _uploadedFileRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.UploadedFile;


        //    finded = _passwordRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.Password;

        //    finded = EmailAddressRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.Email;

        //    finded = RangeRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.Range;

        //    finded = DataLableRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.DataViewField;

        //    finded = _citySelectRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.CitySelect;

        //    finded = _numericInputRequestViewModelProperties?.FirstOrDefault(o => o.Name == targetPropertyType.Name);
        //    if (finded is not null)
        //        return ModelFieldTypes.NumericInput;

        //    return ModelFieldTypes.Unkown;
        //}

        #region Utilities
        //private async Task<TagHelperOutput> CreateLabelElement(TagHelperContext context)
        //{
        //    LabelTagHelper labelTagHelper =
        //        new LabelTagHelper(Generator)
        //        {
        //            For = this.For,
        //            ViewContext = this.ViewContext
        //        };

        //    TagHelperOutput labelOutput = CreateTagHelperOutput("label");

        //    await labelTagHelper.ProcessAsync(context, labelOutput);

        //    labelOutput.Attributes.Add(
        //        new TagHelperAttribute("class", _defaultLabelClass));

        //    return labelOutput;
        //}
        //private const string _forAttributeName = "asp-for";
        //private const string _defaultWraperDivClass = "form-group";
        //private const string _defaultRowDivClass = "row";
        //private const string _defaultLabelClass = "col-md-3 col-form-label";
        //private const string _defaultInputClass = "form-control";
        //private const string _defaultInnerDivClass = "col-md-9";
        //private const string _defaultValidationMessageClass = "";

        //public FormfieldTagHelper(IHtmlGenerator generator)
        //{
        //    Generator = generator;
        //}

        //[HtmlAttributeName(_forAttributeName)]
        //public ModelExpression For { get; set; }

        //public IHtmlGenerator Generator { get; }

        //[ViewContext]
        //[HtmlAttributeNotBound]
        //public ViewContext ViewContext { get; set; }

        //private async Task<TagHelperOutput> CreateValidationMessageElement(TagHelperContext context)
        //{
        //    ValidationMessageTagHelper validationMessageTagHelper =
        //        new ValidationMessageTagHelper(Generator)
        //        {
        //            For = this.For,
        //            ViewContext = this.ViewContext
        //        };

        //    TagHelperOutput validationMessageOutput = CreateTagHelperOutput("span");

        //    await validationMessageTagHelper.ProcessAsync(context, validationMessageOutput);

        //    return validationMessageOutput;
        //}
        //private async Task<TagHelperOutput> CreateInputElement(TagHelperContext context)
        //{
        //    InputTagHelper inputTagHelper =
        //        new InputTagHelper(Generator)
        //        {
        //            For = this.For,
        //            ViewContext = this.ViewContext
        //        };

        //    TagHelperOutput inputOutput = CreateTagHelperOutput("input");

        //    await inputTagHelper.ProcessAsync(context, inputOutput);

        //    inputOutput.Attributes.Add(
        //        new TagHelperAttribute("class", _defaultInputClass));

        //    return inputOutput;
        //}
        //private async Task<TagHelperOutput> CreateSelectElement(TagHelperContext context)
        //{
        //    SelectTagHelper inputTagHelper =
        //        new SelectTagHelper(Generator)
        //        {
        //            For = this.For,
        //            ViewContext = this.ViewContext
        //        };

        //    TagHelperOutput inputOutput = CreateTagHelperOutput("input");

        //    await inputTagHelper.ProcessAsync(context, inputOutput);

        //    inputOutput.Attributes.Add(
        //        new TagHelperAttribute("class", _defaultInputClass));

        //    return inputOutput;
        //}
        private TagHelperOutput CreateTagHelperOutput(string tagName)
        {
            return new TagHelperOutput(
                tagName: tagName,
                attributes: new TagHelperAttributeList(),
                getChildContentAsync: (s, t) =>
                {
                    return Task.Factory.StartNew<TagHelperContent>(
                            () => new DefaultTagHelperContent());
                }
            );
        }
        private IHtmlContent WrapElementsWithDiv(List<IHtmlContent> elements, string classValue)
        {
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass(classValue);
            foreach (IHtmlContent element in elements)
            {
                div.InnerHtml.AppendHtml(element);
            }

            return div;
        }

        #endregion
    }
}
