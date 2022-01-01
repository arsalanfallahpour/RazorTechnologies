using DotNetCenter.Core;

using Microsoft.AspNetCore.Components.Routing;

using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.Segments;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
namespace RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup
{
    public class LayoutScope : BaseLayoutHtmlTag, ILayoutScope
    {

        public LayoutScope(bool isReaddonly, bool disable)
        {
            IsReaddonly = isReaddonly;
            Disable = disable;
        }
        public bool IsReaddonly { get; }
        public bool Disable { get; }
        public ILayoutScopeGroupHeader Header => header;
        private readonly LayoutScopeGroupHeader header = new();
        public ILayoutScopeGroupBody Body => body;
        private readonly LayoutScopeGroupBody body = new();
        public ILayoutScopeGroupFooter Footer => footer;
        private readonly LayoutScopeGroupFooter footer = new();
        public IReadOnlyList<LayoutScopeGroup> ScopeGroups => _scopeGroups;


        private readonly List<LayoutScopeGroup> _scopeGroups = new();

        public ILayoutString GetLayoutString(ref LayoutApiDataParameter parameter)
        {
            var content = NewScopeGroupContainer(ref parameter);
            var sb = new StringBuilder();
            sb.Append("<div id='lbs_cont' class='' style=''>");
            sb.Append("<div id='lbsh_cont' class='' style=''>");
            sb.Append("</div>");
            sb.Append("<div id='lbsb_cont' class='' style=''>");
            sb.Append(RenderHtmlTag(GetScopeContainerTag(ref parameter)));
            sb.Append("</div>");
            sb.Append("<div id='lbsf_cont' class='' style=''>");
            sb.Append("</div>");
            sb.Append("</div>");
            return new LayoutString(sb.ToString());
        }

        private IHtmlTag GetScopeContainerTag(ref LayoutApiDataParameter parameter)
        {
            if (parameter is null || !parameter.IsSupportViewModel)
                throw new Exception(nameof(parameter));
            var content = string.Empty;
            if (parameter.IsValueType)
                throw new NotImplementedException();
            var sb = new StringBuilder();
            var enumProperties = parameter.DataProperties
                .Where(o => !o.IsCustomIgnored )
                .GetEnumerator();
            while(enumProperties.MoveNext())
            {
                ApiDataProperty property = enumProperties.Current;
                if (property.UiControl is null)
                    throw new NullReferenceException($"Unkown UiControl <{nameof(property.UiControl)}>");
                //var selectedData = LayoutBodyDataCollection?.Where(o => o.FullName == property.FullName).ToArray();
                //if (selectedData is null)
                //    throw new Exception($"Property Not Find On Target ViewModel {initialData}");

                //if (selectedData.Length < 1)
                //    throw new Exception($"Property Not Find On Target ViewModel {initialData}");

                //if (selectedData.Length > 1)
                //    throw new Exception($"Property Not Find On Target ViewModel {initialData}");


                IValueModel valueModel = new StringValueModel(string.Empty);
                if (property.DefaultValue is null || !property.DefaultValue.HasValue())
                    valueModel = property.DefaultValue;
                sb.Append(property.UiControl.GenerateLayout(valueModel)) ;
            }
            HtmlTagContent htmlTagContent = new HtmlTagContent(sb.ToString());
            HtmlTagModel htmlTag = new (string.Empty);
            htmlTag.SetTagId(new HtmlTagAttrId("lbsh_cont"));
            htmlTag.SetTagClass(new HtmlTagAttrClass("w-100 bg-transparent p-4"));
            htmlTag.SetTagScript(new HtmlTagAttrScript(string.Empty));
            htmlTag.SetTagContent(htmlTagContent);
            htmlTag.SetTagName(new HtmlTagContent("div"));
            return htmlTag;
        }

        public  HtmlTagContent NewScopeGroupContainer(ref LayoutApiDataParameter parameter)
        {
            var sb = new StringBuilder();
            var headerLayout = header.GetLayoutString();
            var footerLayout = footer.GetLayoutString();
            var bodyLayout = body.GetLayoutString();

            sb.Append("<div id='lbsg_wrap' class='' style=''>");
            sb.Append(headerLayout);
            sb.Append(bodyLayout);
            sb.Append(footerLayout);
            sb.Append("</div>");
            return new HtmlTagContent(sb.ToString());
        }
        public override HtmlTagModel NewHtmlTag(HtmlTagContent htmlTagContent)
            => throw new NotImplementedException();
        public override HtmlTagAttrName NewTagName()
            => throw new NotImplementedException();
        public override HtmlTagAttrId NewTagId()
            => throw new NotImplementedException();
    }
}
