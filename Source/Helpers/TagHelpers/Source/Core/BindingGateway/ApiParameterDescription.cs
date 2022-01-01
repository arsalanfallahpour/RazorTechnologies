using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

using RazorTechnologies.TagHelpers.Core.Common;
using RazorTechnologies.TagHelpers.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public class ApiParameterDescription : IParameterDescription
    {
        public ApiParameterDescription(string parameterTypeName, Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription parameterDescription)
        {
            ParameterDescription = parameterDescription ?? throw new ArgumentNullException(nameof(parameterDescription));
#if NET5_0
            BindingInfo = ParameterDescription?.BindingInfo ?? throw new ArgumentNullException(nameof(parameterDescription));
#endif
            Name = ParameterDescription?.Name;
            DisplayName = ViewModelMetadata?.DisplayName;
            FullName = $"{parameterTypeName}.{Name}";
            BindingName = $"{parameterDescription.ParameterDescriptor.Name}.{Name}";
            Type = ParameterDescription?.Type;
            BiningSource = ParameterDescription?.Source;
            ViewModelMetadata = (DefaultModelMetadata)ParameterDescription?.ModelMetadata;
            ///???
            //ViewModelMetadata.AdditionalValues = parameterDescription.;
        }
        public DefaultModelMetadata ViewModelMetadata { get; }
        public IModelAttribute Attribute { get; }
        public string DisplayName { get; }
        public string Name { get; }
        public string FullName { get; }
        public string BindingName { get; }
        public bool IsOptional { get; }
        public object DefaultValue { get; }
        public Type Type { get; }
        public BindingSource BiningSource { get; }
#if NET5_0
        public BindingInfo BindingInfo { get;}
#endif
        public Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription ParameterDescription { get; }
    }
}
