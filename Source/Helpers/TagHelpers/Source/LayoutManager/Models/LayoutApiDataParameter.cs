using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using MediatR;

using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models
{
    public class LayoutApiDataParameter
    {

        public LayoutApiDataParameter(ParameterMetadata parameterMetadata, int order, IReadOnlyList<ILayoutControlType> customControlTypes)
        {
            ApiParameterRquestViewModelType = parameterMetadata.Type;
            var appType = new AppType(ApiParameterRquestViewModelType);
            IsSupportViewModel = appType.HasBaseType<BaseAppRequestViewModel>();
            if (IsSupportViewModel)
            {
                if (!appType.TryCreateInstance<BaseAppRequestViewModel>(new Type[] { }, out var instance))
                    throw new NullReferenceException($"Parameter must inhrit from <{nameof(BaseAppRequestViewModel)}>");
                ApiParameterRquestViewModel = instance;

                if (!appType.TryGetTypePropertyValue<BaseAppResponseViewModel>(ApiParameterRquestViewModel, nameof(BaseAppRequestViewModel.ResponseViewModel), out var responseViewModel))
                    throw new NullReferenceException($"Property not find on target RequestViewModel<{ApiParameterRquestViewModelType}.{nameof(BaseAppRequestViewModel.ResponseViewModel)}>");

                ApiParameterResponseViewModel = responseViewModel;
                ApiParameterResponseViewModelType = responseViewModel.GetType();
            }


            ValidateRules(parameterMetadata);

            ApiParameterName = parameterMetadata.Name;
            DataPropertyNames = parameterMetadata.BindingPropertyNames;

            if (!IsValueType)
            {
                SetCustomControlType(customControlTypes);
                FillDataProperties(parameterMetadata.ParameterDescriptions.AsEnumerable());
            }
            ApiParameterOrder = order;
            ApiParameterIndex = order - 1;
        }

        private void ValidateRules(ParameterMetadata parameterMetadata)
        {
            if (ApiParameterRquestViewModelType.IsAbstract)
                //ParameterTypeProvider
                throw new InvalidOperationException($"Abstract class Not supported yet {nameof(LayoutApiDataParameter)}.{nameof(ApiParameterRquestViewModelType)}<{nameof(ApiParameterRquestViewModelType)}>!");

            if (ApiParameterRquestViewModelType.IsInterface)
                //ParameterTypeProvider
                throw new InvalidOperationException($"Interface Not supported yet {nameof(LayoutApiDataParameter)}.{nameof(ApiParameterRquestViewModelType)}<{nameof(ApiParameterRquestViewModelType)}>!");

            if (parameterMetadata is null)
                throw new ArgumentNullException(nameof(parameterMetadata));
        }

        public IReadOnlyList<ILayoutControlType> CustomControlTypes { get; private set; }
        public void SetCustomControlType(IReadOnlyList<ILayoutControlType> customControlTypes) => CustomControlTypes = customControlTypes;

        public string ApiParameterName { get; }
        public Type ApiParameterRquestViewModelType { get; }
        public BaseAppResponseViewModel ApiParameterResponseViewModel { get; }
        public Type ApiParameterResponseViewModelType { get; }
        public bool IsValueType => ApiParameterRquestViewModelType.IsValueType;
        public bool IsGenericType => ApiParameterRquestViewModelType.IsGenericType;
        public Guid ViewModelTypeGuid => ApiParameterRquestViewModelType.GUID;
        public int ApiParameterOrder { get; }
        public int ApiParameterIndex { get; }
        public IEnumerable<ApiDataProperty> DataProperties => _DataProperties;
        private readonly List<ApiDataProperty> _DataProperties = new();
        public IEnumerable<string> DataPropertyNames { get; }
        public string ViewModelName => ApiParameterRquestViewModelType.Name;

        public BaseAppRequestViewModel ApiParameterRquestViewModel { get; }
        public bool IsSupportViewModel { get; }

        private void FillDataProperties(IEnumerable<IParameterDescription> apiParameterDescriptions)
        {
            using var enumApiParameter = apiParameterDescriptions.GetEnumerator();
            while (enumApiParameter.MoveNext())
                AddDataProperty(enumApiParameter.Current);
        }
        private bool AddDataProperty(IParameterDescription parameterDescription)
        {
            if (parameterDescription is null)
                throw new ArgumentNullException(nameof(parameterDescription));

            if (parameterDescription.ViewModelMetadata is null)
                throw new ArgumentNullException(nameof(parameterDescription.ViewModelMetadata));

            if (parameterDescription.ViewModelMetadata.MetadataKind != ModelMetadataKind.Property)
                return false;

            if (_DataProperties.Any(o => o.Name == parameterDescription.Name))
                return false;

            _DataProperties.Add(new ApiDataProperty(ApiParameterName, parameterDescription, ViewModelTypeGuid));
            return true;
        }
        public bool TrySetDataPropertyControlTypes(out string invalidParameterTypeFullName)
        {
            invalidParameterTypeFullName = string.Empty;
            if (!IsSupportViewModel)
            {
                CustomControlTypes = null;
                return true;
            }

            var tempCustomTypes = new List<ILayoutControlType>();
            using (var enumProperties = _DataProperties.Where(o => !o.IsCustomIgnored ).GetEnumerator())
            {
                while (enumProperties.MoveNext())
                {
                    if (!enumProperties.Current.TrySetControlType(CustomControlTypes, out invalidParameterTypeFullName))
                        return false;
                    if (enumProperties.Current.BindedToCustomControl)
                        tempCustomTypes.Add(enumProperties.Current.CustomControlType);
                }
            }

            CustomControlTypes = tempCustomTypes;
            return true;
        }

        public bool TryBuildDataPropertyUiControl(TagHelperStates formState,
                                              HtmlTagAttrId layoutId,
                                              HtmlTagAttrId layoutContainerId,
                                              HtmlTagAttrId layoutFormId,
                                              HtmlTagAttrName layoutFormName,
                                              IMediator mediator,
                                              out string failedParameterFullName)
        {
            failedParameterFullName = string.Empty;
            if (_DataProperties is null)
                return true;
            if (!_DataProperties.Any())
                return true;
            using (var enumProperties = _DataProperties.Where(o => !o.IsCustomIgnored ).GetEnumerator())
                while (enumProperties.MoveNext())
                    if (!enumProperties.Current.TryCreateUiControlInstance(new BindingViewModelOption(ViewModelName, ApiParameterName),
                                                                           layoutId,
                                                                           layoutContainerId,
                                                                           layoutFormId,
                                                                           layoutFormName,
                                                                           formState,
                                                                           mediator,
                                                                           out failedParameterFullName))
                        return false;

            return true; ;
        }
    }
}