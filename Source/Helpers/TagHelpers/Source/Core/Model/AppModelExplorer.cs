using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.Model
{
    public class AppModelExplorer : ModelExplorer, IModelExplorer
    {
        public AppModelExplorer(IModelMetadataProvider metadataProvider, ModelMetadata metadata, object model) : base(metadataProvider, metadata, model)
        {
        }

        public AppModelExplorer(IModelMetadataProvider metadataProvider, ModelExplorer container, ModelMetadata metadata, Func<object, object> modelAccessor) : base(metadataProvider, container, metadata, modelAccessor)
        {
        }

        public AppModelExplorer(IModelMetadataProvider metadataProvider, ModelExplorer container, ModelMetadata metadata, object model) : base(metadataProvider, container, metadata, model)
        {
        }
    }
}
