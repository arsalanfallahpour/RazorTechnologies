using System;
using System.Text;

using DotNetCenter.Core;

using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public class LayoutFooter : BaseLayoutHtmlTag, ILayoutFooter
    {
        public LayoutFooter(LayoutTypes layoutType,
            LayoutFooterActionButtonWrapper actionButtonWrapper
            //, HtmlTagContent submitButtonContent
            )
        {
            LayoutType = layoutType;
            ActionButtonWrapper = actionButtonWrapper ?? throw new ArgumentNullException(nameof(actionButtonWrapper));
            //SubmitButtonText = submitButtonContent ?? throw new ArgumentNullException(nameof(submitButtonContent));
        }
        public LayoutFooterActionButtonWrapper ActionButtonWrapper { get; }
        public LayoutTypes LayoutType { get; }
        public bool ActionButtonEnabled { get; private set; }
        //public HtmlTagContent SubmitButtonText { get; }
        public HtmlTagAttrId FormId { get; }
        public IHtmlTag HtmlTag => _htmlTag;
        protected HtmlTagModel _htmlTag;
        public void SetHtmlTag(HtmlTagModel htmlTag)
            => _htmlTag = htmlTag;
        public ILayoutString GetLayoutString()
            => new LayoutString(RenderHtmlTag(NewHtmlTag(NewTagContent())));
        public  HtmlTagContent NewTagContent()
        {
            var sb = new StringBuilder();
            sb.Append("<div id='lfab_wrap' class='' style=''>");
            if (LayoutType != LayoutTypes.JustReadable)
                sb.Append(ActionButtonWrapper.GetLayoutString());
            sb.Append("</div>");
            return new HtmlTagContent(sb.ToString());
        }
        public override HtmlTagModel NewHtmlTag(HtmlTagContent htmlTagContent)
        {
            HtmlTagModel htmlTag = new (String.Empty);
            htmlTag.SetTagId(new HtmlTagAttrId("lf_cont"));
            htmlTag.SetTagClass(new HtmlTagAttrClass("w-100 bg-transparent p-4"));
            htmlTag.SetTagScript(new HtmlTagAttrScript(String.Empty));
            htmlTag.SetTagContent(htmlTagContent);
            htmlTag.SetTagName(new HtmlTagContent("div"));
            return htmlTag;
        }
        public override HtmlTagAttrName NewTagName()
        {
            throw new System.NotImplementedException();
        }
        public bool SaveLayoutFile()
        {
            throw new System.NotImplementedException();
        }

        public override HtmlTagAttrId NewTagId()
        {
            throw new NotImplementedException();
        }
    }
}