using RazorTechnologies.TagHelpers.Common;
using RazorTechnologies.TagHelpers.Core.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class BindingApiMetadataAttribute : BaseAnnotationAttribute
    {
        public BindingApiMetadataAttribute(string title, ApiTypes apiType, CollabsibleStates collabsibleState = CollabsibleStates.HiddenExpanded)
        {
            Title = title;
            ApiType = apiType;
            CollabsibleState = collabsibleState;
        }
        public bool IgnoreParametersDiscovery { get; set; } = false;
        public string Title { get; }
        public ApiTypes ApiType { get; }
        // TODO Add CollabsibleState Configuration to ResponseViewModel (CollapsibleParameters)
        public CollabsibleStates CollabsibleState { get; }
    }
}
