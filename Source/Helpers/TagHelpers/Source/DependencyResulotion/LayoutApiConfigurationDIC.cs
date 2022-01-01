using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

using RazorTechnologies.TagHelpers.Core;
using RazorTechnologies.TagHelpers.Core.Api;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;

namespace RazorTechnologies.TagHelpers.DependencyResulotion
{
    public static class LayoutApiConfigurationDIC
    {
        public static IServiceCollection RegisteLayoutConfigurations(this IServiceCollection services,
            IEnumerable<LayoutControlType> customControlTypes,
            ApiDescriptionGroup apiDescriptionGroup)

        {
            var serviceProvider = services.BuildServiceProvider();

            MediatR.IMediator mediator = serviceProvider.GetService<IMediator>();
            LayoutApiOptionProvider optionsProvider = new();

            var wrappers = services.RegisterRazorTechnologyApiServices(apiDescriptionGroup);
            optionsProvider.LoadLayoutOptions(ref customControlTypes, ref wrappers, ref mediator);

            services.AddSingleton<ILayoutApiOptionProvider>(optionsProvider);
            wrappers.Dispose();
            return services;
        }
        public static IApiDescriptionWrapperCollection RegisterRazorTechnologyApiServices(this IServiceCollection services,
                                                                            ApiDescriptionGroup apiDescriptionGroup)
        {

            var enumerator = apiDescriptionGroup.Items?.GetEnumerator();
            if (enumerator is null)
                new ApiDescriptionWrapperCollection();

            var appApiDescriptions = new ApiDescriptionWrapperCollection();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                var apiDescriotion = new ApiDescriptionWrapper(current);
                appApiDescriptions.Add(apiDescriotion);
            }

            services.AddSingleton<ILayoutManager, RazorTechnologies.TagHelpers.LayoutManager.LayoutManager>();
            services.AddSingleton<ILayoutFooterActionButtonWrapper, LayoutFooterActionButtonWrapper>();
            return appApiDescriptions;
        }
    }
}
