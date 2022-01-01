using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.LayoutManager;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.Core
{
    public abstract class BaseAppTagHelper : TagHelper, AppTagHelper
    {
        public BaseAppTagHelper(ILayoutManager layoutManager)
        {
            LayoutManager = layoutManager;
            LayoutManager.LoadOptions(
                                       TagHelperState
                    , BindingApiOption
                                      //,LayoutHeaderData
                                      //, SubmitButtonText
                                      );
        }
        public abstract LayoutHeaderData LayoutHeaderData { get; set; }
        public abstract TagHelperStates TagHelperState { get; }
        public ILayoutManager LayoutManager { get; }
        public abstract string DefaultTagName { get; }
        public abstract string Description { get; }
        public virtual string TargetRequestModelTargetBindingArgumentName => "requestModel";
        public abstract BindingApiOption BindingApiOption { get; }
        public abstract HtmlTagContent SubmitButtonText { get; }
        public TagMode DefaultTagMode => TagMode.StartTagAndEndTag;


        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = DefaultTagName;
            output.TagMode = DefaultTagMode;
            output.AddClass("w-100", HtmlEncoder.Default);
            output.AddClass("bg-transparent", HtmlEncoder.Default);
            output.AddClass("p-4", HtmlEncoder.Default);
            return base.ProcessAsync(context, output);

        }
    }
}
