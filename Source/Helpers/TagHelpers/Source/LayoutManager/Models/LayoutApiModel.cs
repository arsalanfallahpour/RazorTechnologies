using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using DotNetCenter.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Common;
using RazorTechnologies.TagHelpers.Core;
using RazorTechnologies.TagHelpers.Core.Api;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.DependencyResulotion;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models
{
    public class LayoutApiModel
    {

        public LayoutApiModel(ILayoutApiOption options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            CustomControlTypes = options.CustomLayoutControlTypes;
            MetadataAttribute = options.ApiDescriptionWrapper.MetaDataAttribute;
            Uri = options.ApiDescriptionWrapper.Uri;
            RelativePath = options.ApiDescriptionWrapper.ApiDescription.RelativePath;
            BindingApiOption = options.ApiDescriptionWrapper.BindingApiOption;
            HttpMethod = options.ApiDescriptionWrapper.HttpMethod;
            IsParameterless = options.ApiDescriptionWrapper.IsParameterless;

            LayoutId = new HtmlTagAttrId(7);
            LayoutFormId = new HtmlTagAttrId(7);
            LayoutContainerId = new HtmlTagAttrId(7);
            LayoutFormName = new HtmlTagAttrName($"n{CuidGenerator.NewCuid(7)}");

            //RelativePath = descriptionWrapper.ApiDescription.SupportedRequestFormats.RelativePath;
            //RelativePath = descriptionWrapper.ApiDescription.SupportedResponseTypes.RelativePath;
            _ = BuildDataModels();
            
            bool BuildDataModels()
            {
                if (MetadataAttribute.IgnoreParametersDiscovery)
                    return true;

                var order = 1;
                var isAllBuild = true;
                using var enumApiParameter = options.ApiDescriptionWrapper.ParameterMetadatas.GetEnumerator();
                while (enumApiParameter.MoveNext())
                    isAllBuild &= AddDataModel(enumApiParameter.Current, order++);

                return isAllBuild;
                bool AddDataModel(ParameterMetadata parameterMetadata, int order)
                {

                    if (parameterMetadata == null)
                        return false;

                    if (_dataParameters is null)
                        throw new NullReferenceException(nameof(parameterMetadata));

                    if (_dataParameters.Any(o => o.ApiParameterName == parameterMetadata.Name))
                        return false;

                    LayoutApiDataParameter dataModel = new(parameterMetadata, order, CustomControlTypes);
                    if (!dataModel.TrySetDataPropertyControlTypes(out string invalidParameterTypeFullName))
                        throw new CustomAttributeFormatException($"One of ApiModel.DataModels.DataColumns<{invalidParameterTypeFullName}> haven't any attribute that implement <{nameof(IViewModelControlAttribute)}> interface or attribute not included in <{nameof(CustomControlTypes)}> that you passed in our services.");

                    if (!dataModel.TryBuildDataPropertyUiControl((TagHelperStates)ApiType,
                                                             LayoutId,
                                                             LayoutContainerId,
                                                             LayoutFormId,
                                                             LayoutFormName,
                                                             options.Mediator,
                                                             out string failedParameterFullName))
                        throw new Exception($"One of Controls fialed to build <{failedParameterFullName}>.");
                    _dataParameters.Add(dataModel);
                    return true;
                }
            }
        }
        private readonly List<LayoutApiDataParameter> _dataParameters = new();
        public HtmlTagAttrId LayoutId { get; }
        public HtmlTagAttrId LayoutContainerId { get; }
        public HtmlTagAttrId LayoutFormId { get; }
        public HtmlTagAttrName LayoutFormName { get; }

        public Uri Uri { get; }
        public string RelativePath { get; }
        public BindingApiMetadataAttribute MetadataAttribute { get; }
        public ApiTypes ApiType => MetadataAttribute.ApiType;
        public string Title => MetadataAttribute.Title;
        public BindingApiOption BindingApiOption { get; }
        public System.Net.Http.HttpMethod HttpMethod { get; }
        public bool IsParameterless { get; }

        public IEnumerable<LayoutApiDataParameter> DataParameters => _dataParameters;
        public IReadOnlyList<ILayoutControlType> CustomControlTypes { get; }
        public Guid Key { get; } = Guid.NewGuid();

        public IEnumerable<string> ExportParameterProperties(string parameterName)
        {
            var dataParameter = _dataParameters?.FirstOrDefault(o => o.ApiParameterName == parameterName);

            if (dataParameter == null) throw new KeyNotFoundException();
            return dataParameter.DataPropertyNames;
        }
        public LayoutApiSnapshot ExportDataParameters()
        {
            var output = new LayoutApiSnapshot(BindingApiOption);
            for (int i = 0; i < _dataParameters.Count; i++)
                output.Add(_dataParameters[i]);


            return output;
        }
    }
}