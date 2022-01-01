using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.DependencyResulotion;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public class LayoutManagerOptionProvider : ILayoutManagerOptionProvider
    {
        public LayoutManagerOptionProvider(ILayoutManagerOptionLookupService service)
            => LookupService = service ?? throw new System.ArgumentNullException(nameof(service));

        public ILayoutManagerOptionLookupService LookupService { get; }

        public LayoutManagerOption GetOptions(
                                                                 BindingApiOption bindingApiOption,
                                                                 //LayoutHeaderData layoutHeaderData,
                                                                 TagHelperStates TagHelperState
                                                                 //, HtmlTagContent submitButtonContent
            )
            => LookupService.LookupFor(TagHelperState,
                                       bindingApiOption
                                       //,layoutHeaderData,
                                       //,submitButtonContent
                );
    }
}