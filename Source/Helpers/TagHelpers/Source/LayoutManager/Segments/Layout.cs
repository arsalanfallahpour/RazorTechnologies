using System;
using System.Text;

using DotNetCenter.Core;

using Microsoft.Extensions.Options;

using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
namespace RazorTechnologies.TagHelpers.LayoutManager.Segments
{
    public class Layout : BaseLayoutHtmlTag, ILayout
    {
        public Layout(LayoutTypes layoutType)
        {
            LayoutType = layoutType;
        }
        public LayoutTypes LayoutType { get; }

        public ILayoutHeader LayoutHeader { get; private set; }
        public void SetLayoutHeader(ILayoutHeader layoutHeader)
            => LayoutHeader = layoutHeader;
        public ILayoutFooter LayoutFooter { get; private set; }
        public void SetLayoutFooter(ILayoutFooter layoutFooter)
        => LayoutFooter = layoutFooter;
        public ILayoutBody LayoutBody { get; private set; }
        public void SetLayoutBody(ILayoutBody layoutBody)
            => LayoutBody = layoutBody;
        public LayoutString GetLayoutString(ILayoutGeneratorOptions options)
        {
            var sb = new StringBuilder();
            var content = NewTagContent();
            sb.Append(RenderHtmlTag(NewHtmlTag(content, options)));
            return new LayoutString(sb.ToString());
        }

        private IHtmlTag NewHtmlTag(HtmlTagContent content, ILayoutGeneratorOptions options)
        {
            HtmlTagModel htmlTag = new HtmlTagModel(string.Empty);
            htmlTag.SetName(new(string.Empty));
            htmlTag.SetTagId(options.LayoutId);
            htmlTag.SetTagClass(new HtmlTagAttrClass("w-100 bg-transparent p-5"));
            htmlTag.SetTagScript(new HtmlTagAttrScript(String.Empty));
            htmlTag.SetTagContent(content);
            htmlTag.SetTagName(new HtmlTagContent("div"));
            return htmlTag;
        }

        public static Layout NewLayout(LayoutTypes layoutType)
            => new(layoutType);
            
        public override HtmlTagModel NewHtmlTag(HtmlTagContent htmlTagContent)
            => throw new NotImplementedException();
        public override HtmlTagAttrName NewTagName()
            => throw new NotImplementedException();
        public  HtmlTagContent NewTagContent()
        {
            var headerLayout = LayoutHeader.GetLayoutString();
            var footerLayout = LayoutFooter.GetLayoutString();
            var bodyLayout = LayoutBody.GetLayoutString();
            var sb = new StringBuilder();
            sb.Append(headerLayout);
            sb.Append(bodyLayout);
            sb.Append(footerLayout);
            return new HtmlTagContent(sb.ToString());
        }
        public override HtmlTagAttrId NewTagId()
            => new();
    }
}
