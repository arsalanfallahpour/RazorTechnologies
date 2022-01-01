using System;
using System.Net.Http;

using DotNetCenter.Core;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagAttrMethod  : HtmlTagAttribute, IHtmlTagAttrMethod
    {

        public HtmlTagAttrMethod(HttpMethod method)
        : base(method.Method) 
            => Method = method;

        public override string AttributeName => "method";

        public HttpMethod Method { get; }
    }
}