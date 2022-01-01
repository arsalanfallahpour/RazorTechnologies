using System;
using System.Collections.Generic;
using System.Linq;

using MediatR;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;

namespace RazorTechnologies.TagHelpers.Core.Api
{
    public class LayoutApiOptionProvider : ILayoutApiOptionProvider
    {

        public LayoutApiOptionProvider()
        {
            _options = new();
        }

        public ILayoutApiOptionCollection Options => _options;

        public bool IsLoaded { get; private set; }

        private readonly LayoutApiOptionCollection _options;
        public bool LoadLayoutOptions(ref IEnumerable<LayoutControlType> customControlType, ref IApiDescriptionWrapperCollection apiDescriptionWrappers, ref IMediator mediator)
        {
            if (apiDescriptionWrappers is null)
                throw new ArgumentNullException(nameof(apiDescriptionWrappers));

            var enumWrappers = apiDescriptionWrappers.GetEnumerator();
            while (enumWrappers.MoveNext())
            {

                if (enumWrappers.Current?.BindingApiOption is null)
                    continue;

                if (_options.Any(o => o.ApiDescriptionWrapper.BindingApiOption == enumWrappers.Current.BindingApiOption))
                    continue;

                _options.AddApiOptions(new LayoutApiOption(enumWrappers.Current, mediator,  customControlType));
            }

            IsLoaded = true;
            return true;
        }

        public void LoadCustomOptions(LayoutApiOption option)
        {
            _options.AddApiOptions
                (option);
        }
        public void LoadCustomOptions(IEnumerable<LayoutApiOption> options)
        {
            _options.AddApiOptions(options);
        }
    }
}