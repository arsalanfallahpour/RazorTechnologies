using System;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public interface ILayoutManager : GeneratableTagHelper
    {
        public IHttpContextAccessor HttpContextAccessor { get; }
        public HtmlTagAttrId LayoutContainerId { get; }
        public HtmlTagAttrId LayoutFormId { get; }
        public Guid Key { get; }
        public ILayoutManagerOption Options { get; }   
        public void LoadOptions(
                                    TagHelperStates tagHelperState
                                    ,BindingApiOption bindingApiOption
                                    // , LayoutHeaderData layoutHeaderData
                                    //, HtmlTagContent submitButtonText
            );
    }
}
