using System;

using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

using RazorTechnologies.TagHelpers.Core.Common;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public interface IParameterDescription
    {
        public DefaultModelMetadata ViewModelMetadata { get; }
        public IModelAttribute Attribute { get; }
        public string DisplayName { get; }
        public string Name { get; }
        public string FullName { get; }
        public string BindingName { get; }
        public bool IsOptional { get; }
        public object DefaultValue { get; }
        public BindingSource BiningSource { get; }
        public Type Type { get; }
    }
}