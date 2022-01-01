using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DotNetCenter.Core;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public class LayoutHeader : ILayoutHeader
    {

        public LayoutHeader(LayoutTypes layoutType,
string title,
string subTitle,
ILayoutHeaderBreadcrumb breadcrumb,
LayoutHeaderData headerData)
        {
            _htmlTag = new HtmlTagModel(title);
            LayoutType = layoutType;
            Title = title;
            SubTitle = subTitle;
            Breadcrumb = breadcrumb;
            HeaderData = headerData;
        }

        public IHtmlTag HtmlTag => _htmlTag; 
        private readonly HtmlTagModel _htmlTag;

        public LayoutTypes LayoutType { get; }
        public string Title { get; }
        public string SubTitle { get; }
        public ILayoutHeaderBreadcrumb Breadcrumb { get; }
        public LayoutHeaderData HeaderData { get; }
        public LayoutApiModel LayoutApiModel { get; private set; }

        public ILayoutString GetLayoutString()
        {
            StringBuilder sb = new();
            //??~
            var content = BuildNewTagContent();
            BuildNewTag(content);
            sb.Append(RenderHtmlTag(HtmlTag));
            return new LayoutString(sb.ToString());
        }

        private void BuildNewTag(HtmlTagContent htmlTagContent)
        {
            HtmlTagAttrName htmlTagName = NewTagName();
            _htmlTag.SetTagId(new HtmlTagAttrId("lh_cont"));
            _htmlTag.SetTagClass(new HtmlTagAttrClass(string.Empty));
            _htmlTag.SetTagScript(new HtmlTagAttrScript(string.Empty));
            _htmlTag.SetName(htmlTagName);
            _htmlTag.SetTagContent(htmlTagContent);
        }


        public void LoadApiModel(LayoutApiModel apiModel)
            => LayoutApiModel = apiModel ?? throw new ArgumentNullException(nameof(apiModel));
        private HtmlTagContent BuildNewTagContent()
        {
            StringBuilder sb = new();
            sb.Append("<div id=\'lhd_wrap\' style=\'width:100%;\'>");
            //??~
            sb.Append(RenderHeaderLayoutData());
            sb.Append("</div>");
            _htmlTag.SetTagContent(new HtmlTagContent(sb.ToString()));
            return new HtmlTagContent(sb.ToString());
        }

        private string RenderHeaderLayoutData()
        {
            StringBuilder sb2 = new();
            if (HeaderData is null || !((ILayoutHeaderData)HeaderData).HasData())
                return sb2.ToString();  
            var headerDataEnum = HeaderData.Data.GetEnumerator();
            while (headerDataEnum.MoveNext())
            {
                sb2.Clear();
                var tag = new HtmlTagModel(string.Empty);

                var htmlTagName = NewTagName();
                tag.SetTagId(new HtmlTagAttrId(htmlTagName.TranslateToIdSyntax().Content));
                tag.SetTagClass(new HtmlTagAttrClass(string.Empty));
                tag.SetTagScript(new HtmlTagAttrScript(string.Empty));
                var innerSb = new StringBuilder();
                //// Crate FormGroup Wrapper => Lable + Control from last proecom 

                innerSb.Append(tag.Content);
                tag.SetTagContent(new HtmlTagContent(innerSb.ToString()));
                sb2.Append(RenderHtmlTag(tag));
            }
            return sb2.ToString();
        }

        private HtmlTagAttrName NewTagName()
        {
            StringBuilder sb = new StringBuilder();
            string id = CuidGenerator.NewCuid(7);
            sb.Append(Title);
            sb.Append('_');
            sb.Append(id);
            sb.Clear();
            var htmlTagName = new HtmlTagAttrName(id);
            return htmlTagName;
        }

        public bool IsAccepted()
        {
            throw new System.NotImplementedException();
        }
    }
}