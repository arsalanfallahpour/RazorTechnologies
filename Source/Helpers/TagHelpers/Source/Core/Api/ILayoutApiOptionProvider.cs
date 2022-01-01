using System.Collections;
using System.Collections.Generic;

using MediatR;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;

namespace RazorTechnologies.TagHelpers.Core.Api
{
    public interface ILayoutApiOptionProvider 
    {
        public bool LoadLayoutOptions(ref IEnumerable<LayoutControlType> customControlType, ref IApiDescriptionWrapperCollection apiDescriptionWrappers, ref IMediator mediator);
        bool MaskeSureOptionsLoaded() => Options is not null && IsLoaded;

        public ILayoutApiOptionCollection Options { get; }
        public bool IsLoaded { get; }
    }
}