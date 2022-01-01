using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using DotNetCenter.Core;

using Microsoft.Extensions.DependencyInjection;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Common;
using RazorTechnologies.TagHelpers.Core.Api;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.DependencyResulotion
{
    public static class TagHelperLayoutManagerDIC
    {
        public static IServiceCollection RegisterTagHelperLayoutManagerServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var apiWrapper=
                                             serviceProvider.GetService<ILayoutApiWrapper>();
            var optionProvider =
                                 serviceProvider.GetService<ILayoutGeneratorOptionProvider>();
            if (apiWrapper is null)
                return services;
            var runtimeGuid = Guid.NewGuid();
            var enumApiWrappers= apiWrapper.GetEnumerator();
            LayoutManagerOptionsCollection optionsCollection = new();
            while (enumApiWrappers.MoveNext())
            {
                var apiModel = enumApiWrappers.Current;
                var options = optionProvider.GetOptions(apiModel.BindingApiOption,
                    (TagHelperStates)apiModel.ApiType);
                if (options is null)
                    continue;
                if (options.ApiModel.IsParameterless)
                    continue;
                if (options.ApiModel.MetadataAttribute.IgnoreParametersDiscovery)
                    continue;
                //layoutGenerator.
                var layoutManagerOption = new LayoutManagerOption(apiModel.Key, apiModel.LayoutContainerId, apiModel.LayoutFormId, apiModel.ExportDataParameters(),(TagHelperStates)apiModel.ApiType, options.ApiModel.BindingApiOption);
                var generator = new LayoutGenerator();

                generator.LoadOptions(options);
                if(!generator.TryBuildLayout())
                    throw new Exception("Building Layout Manager Option Failed");

                LayoutString layoutString = generator.GenerateLayout();
                layoutManagerOption.BuildOutput(layoutString);
                if (!optionsCollection.AddOptions(layoutManagerOption))
                    throw new Exception("Adding Layout Manager Option Failed");
            }
            var lookupService = new LayoutManagerOptionLookupService(optionsCollection);
            var provider = new LayoutManagerOptionProvider(lookupService);

            services.AddSingleton<ILayoutManagerOptionProvider>(provider);
            services.AddSingleton<ILayoutManagerOptionLookupService>(lookupService);
            return services;
        }
        private static LayoutFooterActionButtonWrapper GetSubmitButtonContent(ApiTypes apiType, IHtmlTagAttrId formId)
        {
            var wrapper = new LayoutFooterActionButtonWrapper();
            wrapper.BuildActionButtons((LayoutTypes)apiType, formId);
            return wrapper;
        }
    }
}
