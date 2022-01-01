using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;

using MediatR;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core;
using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.DaySelect;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.MonthSelect;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models
{
    public class ApiDataProperty
    {

        public ApiDataProperty(string apiParameterName, IParameterDescription parameterDescription, Guid containerTypeGuid)
        {
            ApiParameterName = apiParameterName;
            ContainerTypeGuid = containerTypeGuid;
            Name = parameterDescription.Name;
            FullName = parameterDescription.FullName;
            BindingName = parameterDescription.BindingName;
            DisplayName = parameterDescription.ViewModelMetadata.DisplayName;
            DataType = parameterDescription.ViewModelMetadata.ModelType;
            
            ValidatorAttributes = parameterDescription.ViewModelMetadata.ValidatorMetadata;
            Attributes = parameterDescription.ViewModelMetadata.Attributes;

            _ = InitializeAnnotationAttributes();

            _ = InitializeImplicitValidationAttributes();

            _ = TrySetDefaultControlAttribute();

            if (!InitializeViewModelAttributes())
                throw new CustomAttributeFormatException($"One of ApiModel.DataModels.DataColumns haven't any attribute that inherited from <{nameof(BaseViewModelAttribute)}>.");

            IsRequired = parameterDescription.ViewModelMetadata.IsRequired;
            IsReadOnly = parameterDescription.ViewModelMetadata.IsReadOnly;
            IsEnum = parameterDescription.ViewModelMetadata.IsEnum;
            IsBindingRequired = parameterDescription.ViewModelMetadata.IsBindingRequired;
            IsEnumerableType = parameterDescription.ViewModelMetadata.IsEnumerableType;
            IsCollectionType = parameterDescription.ViewModelMetadata.IsCollectionType;
            IsComplexType = parameterDescription.ViewModelMetadata.IsComplexType;
            IsBindingAllowed = parameterDescription.ViewModelMetadata.IsBindingAllowed;
            IsFlagsEnum = parameterDescription.ViewModelMetadata.IsFlagsEnum;
            IsNullableValueType = parameterDescription.ViewModelMetadata.IsNullableValueType;
            IsOptional = parameterDescription.IsOptional;
            IsReferenceOrNullableType = parameterDescription.ViewModelMetadata.IsReferenceOrNullableType;
            ShowForDisplay = parameterDescription.ViewModelMetadata.ShowForDisplay;
            ShowForEdit = parameterDescription.ViewModelMetadata.ShowForEdit;
            EnumNamesAndValues = parameterDescription.ViewModelMetadata.EnumNamesAndValues;
            BiningSource = parameterDescription.BiningSource;
            DefaultValue = new StringValueModel(parameterDescription.DefaultValue is null ? string.Empty :parameterDescription.ToString());
            Order = parameterDescription.ViewModelMetadata.Order;

            IsMediaMediatableUiControl = false;
            IsUiInputControl = false;
            IsUiCollectionControl = false;
        }
        private bool InitializeViewModelAttributes()
        {
            var attrs = Attributes?.PropertyAttributes;
            if (attrs is null)
                return false;
            using var enumAttrs = attrs.GetEnumerator();
            var controlAttrs = new List<BaseViewModelAttribute>();
            while (enumAttrs.MoveNext())
            {
                var attr = enumAttrs.Current as BaseViewModelAttribute;
                if (attr is not null)
                    controlAttrs.Add(attr);
            }
            ViewModelAttributes = controlAttrs.AsReadOnly();
            return true;
        }
        private bool InitializeAnnotationAttributes()
        {
            var attrs = Attributes?.PropertyAttributes;
            if (attrs is null)
                return false;
            using var enumAttrs = attrs.GetEnumerator();
            var controlAttrs = new List<BaseAnnotationAttribute>();
            while (enumAttrs.MoveNext())
            {
                var attr = enumAttrs.Current as BaseAnnotationAttribute;
                if (attr is not null)
                    controlAttrs.Add(attr);
            }
            AnnotationAttributes = controlAttrs.AsReadOnly();

            IsCustomIgnored = AnnotationAttributes
                                    ?.Select(o => o.TypeId as Type)
                                    ?.Any(o => o.GUID.CompareTo(typeof(IgnoredFieldVMAttribute).GUID) == 0) ?? false;

            IsCustomIgnoredBinding = AnnotationAttributes
                                  ?.Select(o => o.TypeId as Type)
                                  ?.Any(o => o.GUID.CompareTo(typeof(IgnoredBindingFieldVMAttribute).GUID) == 0) ?? false;
            return true;
        }
        private bool InitializeImplicitValidationAttributes()
        {
            var attrs = Attributes?.PropertyAttributes;
            if (attrs is null)
                return false;
            using var enumAttrs = attrs.GetEnumerator();
            var controlAttrs = new List<ImplicitValidationAttribute>();
            while (enumAttrs.MoveNext())
            {
                var attr = enumAttrs.Current as ImplicitValidationAttribute;
                if (attr is not null)
                    controlAttrs.Add(attr);
            }
            ImplicitValidationAttributes = controlAttrs.AsReadOnly();


            IsImplicitRequired = ImplicitValidationAttributes
                                    ?.Select(o => o.GetType().GUID)
                                    ?.Any(o => o.CompareTo(typeof(ImplicitRequiredAttribute).GUID) == 0) ?? false;
            return true;
        }
        public bool TrySetControlType(IReadOnlyList<ILayoutControlType> customControlTypes, out string invalidParameterTypeFullName)
        {
            invalidParameterTypeFullName = FullName;
            if (IsCustomIgnored)
                return true;

            if (ControlAttribute is null)
                throw new NullReferenceException("Control Attribute not placed on model property");

            Type defaultAttrType = ControlAttribute.TypeId as Type;


            if (defaultAttrType.GUID.CompareTo(typeof(TextBoxControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.TextBox;

            else if(defaultAttrType.GUID.CompareTo(typeof(MonthSelectControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.MonthSelect;

            else if(defaultAttrType.GUID.CompareTo(typeof(DaySelectControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.DaySelect;

            else if(defaultAttrType.GUID.CompareTo(typeof(EmailBoxControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.EmailBox;

            else if(defaultAttrType.GUID.CompareTo(typeof(PhoneNumberBoxControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.PhoneNumberBox;

            else if (defaultAttrType.GUID.CompareTo(typeof(DataViewLableVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.DataViewLable;

            else if (defaultAttrType.GUID.CompareTo(typeof(CheckboxControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.CheckBox;

            else if (defaultAttrType.GUID.CompareTo(typeof(NumericBoxControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.NumericBox;

            else if (defaultAttrType.GUID.CompareTo(typeof(PersianDatePickerControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.PersianDatePicker;

            else if (defaultAttrType.GUID.CompareTo(typeof(PasswordBoxControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.PasswordBox;

            else if (defaultAttrType.GUID.CompareTo(typeof(ComparePasswordBoxControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.ComparePasswordBox;

            else if (defaultAttrType.GUID.CompareTo(typeof(RangeControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.Range;

            else if (defaultAttrType.GUID.CompareTo(typeof(HiddenInputControlVMAttribute).GUID) == 0)
                ControlType = LayoutControlType.HiddenInput;


            var unknownLayoutType = LayoutControlType.Unknown;
            if (ControlType != unknownLayoutType)
                return true;

            if (customControlTypes is null)
                return false;

            using (var enumCustomControlTypes = customControlTypes.GetEnumerator())
                while (enumCustomControlTypes.MoveNext())
                {
                    if (defaultAttrType.GUID.CompareTo(enumCustomControlTypes.Current.AttributeType.GUID) != 0)
                        continue;
                    ControlType =  LayoutControlType.New(enumCustomControlTypes.Current);
                    CustomControlType = enumCustomControlTypes.Current;
                    return true;
                }

            return !(IsUnkown = ControlType == unknownLayoutType);

        }
        private bool TrySetDefaultControlAttribute()
        {
            if (IsCustomIgnored)
                return true;
            var attrs = Attributes?.PropertyAttributes is null ? null : Attributes.PropertyAttributes.Cast<Attribute>();

            if (attrs is null)
                return false;

            ControlAttribute = attrs.Where(o => (o.TypeId as Type)?.GetInterface(nameof(IViewModelControlAttribute), false) is not null)?.FirstOrDefault();

            return ControlAttribute is null;
        }
        public bool TryCreateUiControlInstance(IBindingViewModelOption bindingViewModelOption,
                                               HtmlTagAttrId layoutId,
                                               HtmlTagAttrId layoutContainerId,
                                               HtmlTagAttrId layoutFormId,
                                               HtmlTagAttrName layoutFormName,
                                               TagHelperStates formState,
                                               IMediator mediator,
                                               out string failedParameterFullName)
        {

            failedParameterFullName = Name;
            if (IsCustomIgnored)
                return true;
            var type = ControlType.ControlType;
            if (type is null)
                throw new InvalidOperationException($"Control Instantiation require control type. Call TrySetControlType berfore try to create instance for it. ApiParamter<{nameof(Name)}:{Name}>");
            if(!TryCreateInstance())
                throw new NoNullAllowedException($"Control Instantiation Failed. ApiParamter<{nameof(Name)}:{Name}>");

            return true;

            bool TryCreateInstance()
            {
                UiControl = null;
                ConstructorInfo constructor = null;
                object obj = null;
                var interfaces = type.GetInterfaces();
                var appType = new AppType(ref type);
                InputHtmlTag htmlTag = new(DisplayName, false);
                HtmlTagAttrName name = new HtmlTagAttrName($"{BindingName}");
                htmlTag.SetName(name);
                htmlTag.SetTagName(new("div"));
                htmlTag.SetTagFormId(new Html.Form.HtmlTagAttrForm(layoutFormId.Content));
                htmlTag.SetTagId(name.TranslateToIdSyntax());
                htmlTag.SetTagClass(new(string.Empty));
                htmlTag.SetTagScript(new(string.Empty));
                if (appType.FindInterface(typeof(ILayoutCollectionControlOptions).GUID, false))
                {

                    constructor = type.GetConstructor(new Type[] { typeof(ILayoutCollectionControlOptions) });
                    if (constructor is null)
                        return false;
                    obj = Activator.CreateInstance(type, new LayoutCollectionControlOptions(bindingViewModelOption, formState));
                    IsUiCollectionControl = true;
                }
                else if (appType.FindInterface(typeof(IMediatableLayoutInputControl).GUID, false))
                {
                    constructor = type.GetConstructor(new Type[] { typeof(ILayoutInputControlOptions), typeof(IMediator) });
                    if (constructor is null)
                        return false;
                    obj = Activator.CreateInstance(type, new LayoutInputControlOptions(
                        layoutId,
                        layoutContainerId,
                        bindingViewModelOption,
                        layoutFormId,
                        layoutFormName, ControlAttribute, htmlTag, formState, false), mediator);
                    IsMediaMediatableUiControl = true;
                    IsUiInputControl = true;
                }
                else if (appType.FindInterface(typeof(IMediatableLayoutControl).GUID, false))
                {
                    constructor = type.GetConstructor(new Type[] { typeof(ILayoutControlOptions), typeof(IMediator) });
                    if (constructor is null)
                        return false;

                    obj = Activator.CreateInstance(type, new LayoutControlOptions(
                                                        layoutId,
                                                        layoutContainerId,
                                           bindingViewModelOption, ControlAttribute, htmlTag, formState));
                    IsMediaMediatableUiControl = true;
                }
                else if (appType.FindInterface(typeof(ILayoutInputControl).GUID, false))
                {
                    constructor = type.GetConstructor(new Type[] { typeof(ILayoutInputControlOptions) });
                    if (constructor is null)
                        return false;
 
                    obj = Activator.CreateInstance(type, new LayoutInputControlOptions(
                        layoutId, 
                        layoutContainerId,
                        bindingViewModelOption,
                        layoutFormId,
                        layoutFormName, ControlAttribute, htmlTag, formState, false));
                    IsUiInputControl = true;
                }
                else if (appType.FindInterface(typeof(ILayoutControl).GUID, false))
                {
                    constructor = type.GetConstructor(new Type[] { typeof(ILayoutControlOptions) });
                    if (constructor is null)
                        return false;

                    obj = Activator.CreateInstance(type, new LayoutControlOptions(
                                            layoutId,
                                            layoutContainerId,
                                           bindingViewModelOption, ControlAttribute,htmlTag , formState));
                }


                if (obj == null)
                    return false;

                UiControl = obj as BaseLayoutControl;
                return UiControl != null;
            }
        }
        public bool BindedToCustomControl => CustomControlType is not null;
        public string Name { get; }
        public string FullName { get; }
        public string BindingName { get; }
        public string DisplayName { get; }
        public IReadOnlyList<object> ValidatorAttributes { get; }
        public ModelAttributes Attributes { get; }
        public ReadOnlyCollection<BaseViewModelAttribute> ViewModelAttributes { get; private set; }
        public ReadOnlyCollection<BaseAnnotationAttribute> AnnotationAttributes { get; private set; }
        public ReadOnlyCollection<ImplicitValidationAttribute> ImplicitValidationAttributes { get; private set; }
        public bool IsMediaMediatableUiControl { get; private set; }
        public bool IsUiInputControl { get; private set; }
        public bool IsCustomIgnored { get; private set; }
        public bool IsCustomIgnoredBinding { get; private set; }
        public bool IsImplicitRequired { get; private set; }
        public bool IsRequired { get; }
        public bool IsReadOnly { get; }
        public bool IsEnum { get; }
        public bool IsBindingRequired { get; }
        public bool IsEnumerableType { get; }
        public bool IsCollectionType { get; }
        public bool IsComplexType { get; }
        public bool IsBindingAllowed { get; }
        public bool IsFlagsEnum { get; }
        public bool IsNullableValueType { get; }
        public bool IsReferenceOrNullableType { get; }
        public bool ShowForDisplay { get; }
        public Type DataType { get; }
        public bool ShowForEdit { get; }
        public IReadOnlyDictionary<string, string> EnumNamesAndValues { get; }
        public BindingSource BiningSource { get; }
        public StringValueModel DefaultValue { get; }
        public int Order { get; }
        public bool IsOptional { get; }
        public string ApiParameterName { get; }
        public Guid ContainerTypeGuid { get; }
        public LayoutControlType ControlType { get; private set; } = LayoutControlType.Unknown;
        public ILayoutControlType CustomControlType { get; private set; }
        public bool IsUnkown { get; private set; }
        public Attribute ControlAttribute { get; private set; }
        public BaseLayoutControl UiControl { get; private set; }
        public bool IsUiCollectionControl { get; private set; }
    }
}