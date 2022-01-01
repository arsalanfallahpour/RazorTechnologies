using System;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;

namespace RazorTechnologies.TagHelpers.DependencyResulotion
{
    public class LayoutGeneratorOptionProvider : ILayoutGeneratorOptionProvider
    {
        public LayoutGeneratorOptionProvider(ILayoutGeneratorOptionLookupService lookupService)
        {
            LookupService = lookupService;
        }

        public ILayoutGeneratorOptionLookupService LookupService { get; }

        public LayoutGeneratorOption GetOptions(BindingApiOption bindingApiOption, TagHelperStates tagHelperState)
            => LookupService.LookupFor(tagHelperState, bindingApiOption);
    }
}