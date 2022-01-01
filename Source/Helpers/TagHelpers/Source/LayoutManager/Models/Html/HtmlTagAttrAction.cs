using System;

using DotNetCenter.Core;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagAttrAction  : HtmlTagAttribute, IHtmlTagAttrAction
    {
      
        public HtmlTagAttrAction(string action)
        : base(action is null ? action :action.StartsWith("/")? action :action.StartsWith("http:") || action.StartsWith("https:") || action.StartsWith("www.") ? action :  action.Insert(0, "/"))
        { }
     
        public override string AttributeName => "action";
    }
}