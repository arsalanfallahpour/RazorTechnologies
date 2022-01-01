using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using RazorTechnologies.TagHelpers.Core.Api;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager;
using RazorTechnologies.TagHelpers.LayoutManager.Models;

namespace RazorTechnologies.TagHelpers.DependencyResulotion
{
    public static class TagHelperModelService
    {
        public static IServiceCollection RegisterTagHelperViewModels(this IServiceCollection services)
        {

            var serviceProvider = services.BuildServiceProvider();

            var LayoutApiOptionProvider =
                                             serviceProvider.GetService<ILayoutApiOptionProvider>();


            var options = LayoutApiOptionProvider.Options;
            if (options is null)
                return services;

            LayoutApiWrapper layoutApiWrapper = new();
            var enumOptions = options.GetEnumerator();
            while (enumOptions.MoveNext())
            {
                var apiModel = new LayoutApiModel(enumOptions.Current);
                layoutApiWrapper.AddLayoutApi(apiModel);
            }



            services.AddSingleton<ILayoutApiWrapper>(layoutApiWrapper);
            services.AddSingleton<ILayoutGeneratorOptionLookupService, LayoutGeneratorOptionLookupService>();
            services.AddSingleton<ILayoutGeneratorOptionProvider, LayoutGeneratorOptionProvider>();
            return services;
        }
    }
}
