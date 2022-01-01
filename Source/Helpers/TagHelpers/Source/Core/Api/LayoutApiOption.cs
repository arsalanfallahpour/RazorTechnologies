using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using RazorTechnologies.TagHelpers.Core;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;

namespace RazorTechnologies.TagHelpers.Core.Api
{
    public class LayoutApiOption : ILayoutApiOption
    {

        public LayoutApiOption(ApiDescriptionWrapper apiDescriptionWrapper, IMediator mediator, IEnumerable<LayoutControlType> customControlType)
        {
            ApiDescriptionWrapper = apiDescriptionWrapper ?? throw new ArgumentNullException(nameof(apiDescriptionWrapper));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _customControlTypes = customControlType?.ToList();
        }

        public ApiDescriptionWrapper ApiDescriptionWrapper { get; }
        public IMediator Mediator { get; }

        public IReadOnlyList<LayoutControlType> CustomLayoutControlTypes => _customControlTypes;
        private readonly List<LayoutControlType> _customControlTypes = new();
    }
}
