using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using System;
using System.Net.Http;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.HtmlForm
{
    public interface IHtmlFormOptions
    {
        public IHtmlTagAttrId HtmlTagId{ get;  }
        public IHtmlTagAttrId HtmlTagUniqueId{ get; }
        public HttpMethod HttpMethod { get; }
        public string ApiRelativePath { get; }

    }
}