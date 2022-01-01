using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public class ParameterMetadata : IParameterMetadata
    {
        public ParameterMetadata(ControllerParameterDescriptor parameterDescriptor, List<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription> apiParameterDescriptions)
        {
            ParameterDescriptor = parameterDescriptor ?? throw new ArgumentNullException(nameof(parameterDescriptor));
            Name = ParameterDescriptor.Name;
            ApiParameterDescriptions = apiParameterDescriptions ?? throw new ArgumentNullException(nameof(apiParameterDescriptions));
            Type = parameterDescriptor.ParameterType;
            _parameterDescriptions = new List<ApiParameterDescription>();
            var metaData = GetParameterDescriptionMetadata();
            _parameterDescriptions.AddRange(metaData);
            BindingPropertyNames = ParameterDescriptions.Select(o => o.Name);
        }

        public List<ApiParameterDescription> GetParameterDescriptionMetadata()
        {
            return  ApiParameterDescriptions.Select(o=>new ApiParameterDescription(Type.Name, o)).ToList();
            //var parameterDiscriptions = new List<ApiParameterDescriptionContainer>();
            //while(enumerator.MoveNext())
            //{
            //    var current = enumerator.Current;
            //    parameterDiscriptions.Add(new ApiParameterDescriptionContainer(Type.Name, current));
            //}
            //return parameterDiscriptions;
        }

        public string Name { get; }
        public Type Type { get; }

        public IReadOnlyList<IParameterDescription> ParameterDescriptions => _parameterDescriptions;
        private List<ApiParameterDescription> _parameterDescriptions;
        public IEnumerable<string> BindingPropertyNames { get; }
        public ControllerParameterDescriptor ParameterDescriptor { get; }
        public List<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription> ApiParameterDescriptions { get; }
    }
}