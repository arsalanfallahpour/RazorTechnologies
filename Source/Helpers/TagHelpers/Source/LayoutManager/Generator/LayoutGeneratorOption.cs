using System;

using DotNetCenter.Core;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator.Output;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.Segments;



namespace RazorTechnologies.TagHelpers.LayoutManager.Generator
{
    public class LayoutGeneratorOption : ILayoutGeneratorOptions
    {
        public LayoutGeneratorOption(LayoutApiModel apiModel
                                      //,HtmlTagContent submitButtonContent
            )
        {
            ApiModel = apiModel;
            LayoutType = (LayoutTypes)apiModel.ApiType;
            //SubmitButtonContent = submitButtonContent;
            FooterActionButtonWrapper = GetFooterActionButtonWrapper();
            LayoutFooterActionButtonWrapper GetFooterActionButtonWrapper()
            {
                var actionButtonWrapper = new LayoutFooterActionButtonWrapper();
                actionButtonWrapper.BuildActionButtons(LayoutType, ApiModel.LayoutFormId);
                return actionButtonWrapper;
            }
        }

        public string Title => ApiModel.Title;
        public LayoutTypes LayoutType { get; }
        public IHtmlTagAttrId LayoutId => ApiModel.LayoutId;
        public IHtmlTagAttrId LayoutFormId => ApiModel.LayoutFormId;
        public IHtmlTagAttrId LayoutContainerId => ApiModel.LayoutContainerId;
        public LayoutApiModel ApiModel { get; }
        public LayoutFooterActionButtonWrapper FooterActionButtonWrapper { get; }
        //public HtmlTagContent SubmitButtonText { get; }
    }
}
