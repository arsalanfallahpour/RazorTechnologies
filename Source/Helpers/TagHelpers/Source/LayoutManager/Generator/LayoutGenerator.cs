using System;
using System.Text;

using RazorTechnologies.TagHelpers.Core;
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
        { }
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
            sb.Append(RenderCollapseButton());
            sb.Append(Layout.GetLayoutString(Options));
            return new LayoutString(sb.ToString());

            string RenderCollapseButton()
            {
                var sb = new StringBuilder();

                switch (Options.CollabsibleState)
                {
                    case CollabsibleStates.ShowCollapsed:
                        sb.Append(RenderCollapseButtonCondition(true, true));
                        break;
                    case CollabsibleStates.HiddenCollapsed:
                        sb.Append(RenderCollapseButtonCondition(false, true));
                        break;
                    case CollabsibleStates.ShowExpanded:
                        sb.Append(RenderCollapseButtonCondition(true, false));
                        break;
                    case CollabsibleStates.HiddenExpanded:
                        sb.Append(RenderCollapseButtonCondition(false, false));
                        break;
                    default:
                        throw new NotSupportedException(nameof(Options.CollabsibleState));

                }
                return sb.ToString();
            }
            string RenderCollapseButtonCondition(bool show, bool collapsed)
            {
                var sb = new StringBuilder();
                sb.Append("<script>" +
                    $"function clsp_{Options.LayoutContainerId}_click() {{" +
                    $"if($('#{BaseAppTagHelper.InnerContainerIdPrefix}{Options.LayoutContainerId}').hasClass('collapse')){{$('#clsp_{Options.LayoutContainerId}').html('- <span class=\\'small text-secondary\\'>{Options.Title}');$('#{BaseRequestTagHelper.InnerContainerIdPrefix}{Options.LayoutContainerId}').removeClass('collapse');$('#clsp_{Options.LayoutContainerId}').removeClass('btn-outline-dark');$('#clsp_{Options.LayoutContainerId}').addClass('btn-dark');}}" +
                    $"else{{$('#clsp_{Options.LayoutContainerId}').html('+ <span class=\\'small text-secondary\\'>{Options.Title}');$('#{BaseRequestTagHelper.InnerContainerIdPrefix}{Options.LayoutContainerId}').addClass('collapse');$('#clsp_{Options.LayoutContainerId}').addClass('btn-outline-dark');$('#clsp_{Options.LayoutContainerId}').removeClass('btn-dark');}}" +
                    "}");
                sb.Append("$(document).ready(function(){");
                sb.Append($"$('#{BaseAppTagHelper.ContainerIdPrefix}{Options.LayoutContainerId}').append('<button id=\\'clsp_{Options.LayoutContainerId}\\' onclick=\\'clsp_{Options.LayoutContainerId}_click();\\' class=\\'btn btn-outline-dark {(show ? string.Empty : " collapse ")}\\'>+ <span class=\\'small text-secondary\\'>{Options.Title}</span></button>')");
                sb.Append("});");
                if (collapsed)
                    sb.Append("$(document).ready(function(){" +
                        $"$('#clsp_{Options.LayoutContainerId}').click();" +
                        "});");
                sb.Append("</script>");


                return sb.ToString();
            }
        }
        public Layout Layout { get; private set; }
        public LayoutTypes LayoutType => (LayoutTypes)Options?.ApiModel?.ApiType;
        public BindingApiOption BindingApiOption => Options?.ApiModel?.BindingApiOption;

        public bool ReadyToPresent { get; private set; } = false;

        public void LoadOptions(LayoutGeneratorOption layoutGeneratorOptions)
            => Options = layoutGeneratorOptions;
    }
}
