using System;
using System.Text;

using Microsoft.AspNetCore.Http;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.Segments;

using segment = RazorTechnologies.TagHelpers.LayoutManager.Segments;

namespace RazorTechnologies.TagHelpers.LayoutManager.Generator
{
    //Singleton
    public class LayoutGenerator : ILayoutGenerator
    {
        public LayoutGenerator()
        {}
        public LayoutGeneratorOption Options { get; private set; }
  
        public bool TryBuildLayout()
        {
            Layout = segment.Layout.NewLayout(LayoutType);
            Layout.SetLayoutHeader(GetHeader());
            Layout.SetLayoutBody(GetBody());
            Layout.SetLayoutFooter(GetFooter());
            return ReadyToPresent = true;
            LayoutHeader GetHeader()
            {
                LayoutHeaderData headerData = new();
                headerData.SetTagClass(new HtmlTagAttrClass(string.Empty));
                headerData.SetTagScript(new HtmlTagAttrScript(string.Empty));
                headerData.SetTagId(new HtmlTagAttrId());
                headerData.SetName(new HtmlTagAttrName($"lhd_{Options.ApiModel.LayoutFormName}"));

                LayoutHeader layoutHeader = new(LayoutType,
                                                                                    Options.ApiModel.Title,
                                                                                 string.Empty,
                                                                                   new LayoutHeaderBreadcrumb(string.Empty),
                                                                                   headerData);
                layoutHeader.LoadApiModel(Options.ApiModel);
                return layoutHeader;
            }
            LayoutBody GetBody()
            {
                var body = new LayoutBody(LayoutType);
                body.LoadApiModel(Options.ApiModel);
                    return body;
            }
            LayoutFooter GetFooter()
                => new(LayoutType,
                       Options.FooterActionButtonWrapper

                       //,Options.SubmitButtonText
                       );
        } 
        public LayoutString GenerateLayout()
        {
            if (Layout is null)
                throw new NullReferenceException("Build layout before generate content");
            var sb = new StringBuilder();
            sb.Append(Layout.GetLayoutString(Options));
            return new LayoutString(sb.ToString());
        }
        public Layout Layout { get; private set; }
        public LayoutTypes LayoutType => (LayoutTypes)Options?.ApiModel?.ApiType;
        public BindingApiOption BindingApiOption => Options?.ApiModel?.BindingApiOption;

        public bool ReadyToPresent { get; private set; } = false;

        public void LoadOptions(LayoutGeneratorOption layoutGeneratorOptions)
            => Options = layoutGeneratorOptions;
    }
}
