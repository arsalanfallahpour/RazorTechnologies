using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using RazorTechnologies.TagHelpers.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public class ApiDescriptionWrapper :
        IApiDescriptionWrapper
    //ApiDescription ,
    {
        public ApiDescriptionWrapper(ApiDescription apiDescription)
        {
            //??????
            //Title = apiDescription.ActionDescriptor.EndpointMetadata.
            ApiDescription = apiDescription ?? throw new ArgumentNullException(nameof(apiDescription));
            MetaDataAttribute =  GetMetadataAttribute();
            Title = MetaDataAttribute.Title;
            Uri = new Uri(ApiDescription.RelativePath, UriKind.Relative) ?? throw new ArgumentNullException(nameof(Uri));
            // - From ArgumentMetadatas
            //From Outside of Api Description
            ParameterMetadatas = GetParameterMetadatas();
            IsParameterless = ParameterMetadatas.Count < 1 ? true : false;
            HttpMethod = new HttpMethod(ApiDescription.HttpMethod);
            ControllerActionDescriptor = (ControllerActionDescriptor)ApiDescription.ActionDescriptor;
            BindingApiOption = new BindingApiOption(ControllerActionDescriptor, HttpMethod);
        }

        private BindingApiMetadataAttribute GetMetadataAttribute()
        {
            var metadatas = ApiDescription.ActionDescriptor.EndpointMetadata;
            var metadatasEnumerator = metadatas.GetEnumerator();
            while(metadatasEnumerator.MoveNext())
            {
                var current = metadatasEnumerator.Current;
                if(current is BindingApiMetadataAttribute bindingMetadataAttr)
                    return  bindingMetadataAttr;
            }
            throw new NullReferenceException("Attribute not placed on the Controller Action");
        }

        private IList<ParameterMetadata> GetParameterMetadatas()
        {
            var parameters = ApiDescription.ActionDescriptor.Parameters;

            var parameterDescriptions = ApiDescription.ParameterDescriptions;
            var parametersEnumerator = parameters.GetEnumerator();
            var parameterDescriptionEnumerator = parameterDescriptions.GetEnumerator();

            var parameterMetadatas = new List<ParameterMetadata>();
            while(parametersEnumerator.MoveNext())
            {
                var param = parametersEnumerator.Current;
                if(param is not ControllerParameterDescriptor controllerParamDescriptor)
                    continue;
                var parameterDiscriptionMetadatas = new List<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription>();
                while(parameterDescriptionEnumerator.MoveNext())
                {
                    var parameterDescription = parameterDescriptionEnumerator.Current;
                    if(parameterDescription.ParameterDescriptor.Name != param.Name)
                        continue;
                    parameterDiscriptionMetadatas.Add(parameterDescription);
                }

                var metaData = new ParameterMetadata(controllerParamDescriptor, parameterDiscriptionMetadatas);
                parameterMetadatas.Add(metaData);
            }
            return parameterMetadatas;
        }

        public ApiDescription ApiDescription { get; }
        public ControllerActionDescriptor  ControllerActionDescriptor{ get; }
        public string Title { get; }
        public HttpMethod HttpMethod { get; }
        public BindingApiOption BindingApiOption { get; }
        public Uri Uri { get; }
        public ApiTypes ApiType => MetaDataAttribute.ApiType;
        public IList<ParameterMetadata> ParameterMetadatas { get; }
        public bool IsParameterless { get; }
        public BindingApiMetadataAttribute MetaDataAttribute { get; }
    }
}
