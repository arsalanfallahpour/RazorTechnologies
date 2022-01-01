using System;
using System.Net.Http;


using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.HtmlForm
{
    public class HtmlFormOptions :  IHtmlFormOptions
    {
        public HtmlFormOptions(string apiRelativePath, HttpMethod httpMethod)
        {
            if (string.IsNullOrEmpty(apiRelativePath))
                throw new ArgumentException($"'{nameof(apiRelativePath)}' cannot be null or empty.", nameof(apiRelativePath));

            ApiRelativePath = apiRelativePath;
            HttpMethod = httpMethod ?? throw new ArgumentNullException(nameof(httpMethod));
            _htmlTagId = new (7);
            _htmlTagUniqueId = new (7); 
        }

        public string ApiRelativePath { get; }
        public HttpMethod HttpMethod { get; }

        public IHtmlTagAttrId HtmlTagId => _htmlTagId;
        private HtmlTagAttrId _htmlTagId;
        public IHtmlTagAttrId HtmlTagUniqueId => _htmlTagUniqueId;
        private HtmlTagAttrId _htmlTagUniqueId;
    }
}