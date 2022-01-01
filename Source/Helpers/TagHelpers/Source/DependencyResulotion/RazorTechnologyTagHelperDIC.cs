using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using RazorTechnologies.TagHelpers.Core;
using RazorTechnologies.TagHelpers.Core.Attr;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.Core.Model;
using RazorTechnologies.TagHelpers.LayoutManager;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace RazorTechnologies.TagHelpers.DependencyResulotion
{
    public static class RazorTechnologyTagHelperDIC
    {
        public static IServiceCollection AddRazorTechnologyTagHelperServices(this IServiceCollection services,
                                                                             ApiDescriptionGroup apiDescriptionGroup,
                                                                             IReadOnlyList<LayoutControlType> customControlTypes)
        {
            //services.AddSingleton<ITagHelperLayoutManegerService, TagHelperLayoutManegerService>();
            services.AddSingleton<IAnnotationAttributeTypeProvider, AnnotationAttributeTypeProvider>();
                services.RegisteLayoutConfigurations( customControlTypes, apiDescriptionGroup);
            services.RegisterTagHelperViewModels();
            services.RegisterTagHelperLayoutManagerServices();
            return services;
        }
    }
}
