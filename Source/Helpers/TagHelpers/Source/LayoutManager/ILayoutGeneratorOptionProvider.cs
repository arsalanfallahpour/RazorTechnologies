using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutGeneratorOptionProvider
    {
        public LayoutGeneratorOption GetOptions(BindingApiOption bindingApiOption,
                                                                 TagHelperStates TagHelperState);
        public ILayoutGeneratorOptionLookupService LookupService { get; }

    }
}