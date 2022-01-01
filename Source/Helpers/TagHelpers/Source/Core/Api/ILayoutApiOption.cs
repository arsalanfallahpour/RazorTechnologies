using System.Collections.Generic;

using MediatR;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;

namespace RazorTechnologies.TagHelpers.Core.Api
{
    public interface ILayoutApiOption
    {
        public ApiDescriptionWrapper ApiDescriptionWrapper { get; }
        public IReadOnlyList<LayoutControlType> CustomLayoutControlTypes { get; }
        public IMediator Mediator { get; }
    }
}