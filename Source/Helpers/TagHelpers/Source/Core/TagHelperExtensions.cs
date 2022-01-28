using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers;

using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.Core
{
    public static class TagHelperExtensions
    {
        public static TagHelperOutput CreateTagHelperOutput(this IHtmlTagAttrName tagName)
        {
            if (tagName?.Content is null || !tagName.HasValue())
                throw new NullReferenceException(nameof(tagName));

            return new TagHelperOutput(
                tagName: tagName.ToString(),
                attributes: new TagHelperAttributeList(),
                getChildContentAsync: (s, t) =>
                {
                    return Task.Factory.StartNew<TagHelperContent>(
                            () => new DefaultTagHelperContent());
                }
            );
        }
        //private async Task<TagHelperOutput> CreateLabelElement(TagHelperContext context)
        //{
        //    LabelTagHelper labelTagHelper =
        //        new LabelTagHelper(Generator)
        //        {
        //            For = this.For,
        //            ViewContext = this.ViewContext
        //        };

        //    TagHelperOutput labelOutput = CreateTagHelperOutput("label");

        //    await labelTagHelper.ProcessAsync(context, labelOutput);

        //    labelOutput.Attributes.Add(
        //        new TagHelperAttribute("class", _defaultLabelClass));

        //    return labelOutput;
        //}
        //private const string _forAttributeName = "asp-for";
        //private const string _defaultWraperDivClass = "form-group";
        //private const string _defaultRowDivClass = "row";
        //private const string _defaultLabelClass = "col-md-3 col-form-label";
        //private const string _defaultInputClass = "form-control";
        //private const string _defaultInnerDivClass = "col-md-9";
        //private const string _defaultValidationMessageClass = "";

        //public FormfieldTagHelper(IHtmlGenerator generator)
        //{
        //    Generator = generator;
        //}

        //[HtmlAttributeName(_forAttributeName)]
        //public ModelExpression For { get; set; }

        //public IHtmlGenerator Generator { get; }

        //[ViewContext]
        //[HtmlAttributeNotBound]
        //public ViewContext ViewContext { get; set; }

        //private async Task<TagHelperOutput> CreateValidationMessageElement(TagHelperContext context)
        //{
        //    ValidationMessageTagHelper validationMessageTagHelper =
        //        new ValidationMessageTagHelper(Generator)
        //        {
        //            For = this.For,
        //            ViewContext = this.ViewContext
        //        };

        //    TagHelperOutput validationMessageOutput = CreateTagHelperOutput("span");

        //    await validationMessageTagHelper.ProcessAsync(context, validationMessageOutput);

        //    return validationMessageOutput;
        //}
        //private async Task<TagHelperOutput> CreateInputElement(TagHelperContext context)
        //{
        //    InputTagHelper inputTagHelper =
        //        new InputTagHelper(Generator)
        //        {
        //            For = this.For,
        //            ViewContext = this.ViewContext
        //        };

        //    TagHelperOutput inputOutput = CreateTagHelperOutput("input");

        //    await inputTagHelper.ProcessAsync(context, inputOutput);

        //    inputOutput.Attributes.Add(
        //        new TagHelperAttribute("class", _defaultInputClass));

        //    return inputOutput;
        //}
        //private async Task<TagHelperOutput> CreateSelectElement(TagHelperContext context)
        //{
        //    SelectTagHelper inputTagHelper =
        //        new SelectTagHelper(Generator)
        //        {
        //            For = this.For,
        //            ViewContext = this.ViewContext
        //        };

        //    TagHelperOutput inputOutput = CreateTagHelperOutput("input");

        //    await inputTagHelper.ProcessAsync(context, inputOutput);

        //    inputOutput.Attributes.Add(
        //        new TagHelperAttribute("class", _defaultInputClass));

        //    return inputOutput;
        //}
    }
}
