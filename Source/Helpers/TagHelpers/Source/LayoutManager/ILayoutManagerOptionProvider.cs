using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutManagerOptionProvider
    {
        public LayoutManagerOption GetOptions(BindingApiOption bindingApiOption,
                                        TagHelperStates tagHelperState
                                        //,LayoutHeaderData layoutHeaderData
                                        //,HtmlTagContent submitButtonText
            );

    }
}