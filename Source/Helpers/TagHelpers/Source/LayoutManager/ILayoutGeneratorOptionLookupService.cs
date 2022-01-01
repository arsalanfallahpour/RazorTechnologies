using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutGeneratorOptionLookupService
    {
        public LayoutGeneratorOption LookupFor(TagHelperStates tagHelperState,
                                           BindingApiOption bindingApiOption
                                           //,LayoutHeaderData layoutHeaderData
                                           );
    }
}