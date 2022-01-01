using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.Model;
using System;
using System.Collections.Generic;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public interface IParameterMetadata
    {
        public string Name { get; }
        //public List<ApiParameterDescriptionContainer> ParameterDescriptions { get; }
        public IEnumerable<string> BindingPropertyNames { get; }
    }
}