using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.DependencyResulotion
{
    public interface ILayoutManagerOptionLookupService
    {
        LayoutManagerOption LookupFor(
                                      TagHelperStates tagHelperState,
                                      BindingApiOption bindingApiOption
                                      //,LayoutHeaderData layoutHeaderData
                                      //,IHtmlTagContent submitButtonContent
            );
    }
}