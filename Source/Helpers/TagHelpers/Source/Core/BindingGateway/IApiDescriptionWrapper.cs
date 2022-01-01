using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RazorTechnologies.TagHelpers.Common;
using RazorTechnologies.TagHelpers.Core.Attr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public interface IApiDescriptionWrapper
    {
        public string Title { get; }
        public HttpMethod HttpMethod { get; }
        public Uri Uri { get; }
        public bool IsParameterless { get; }
        public BindingApiOption BindingApiOption { get; }
        public IList<ParameterMetadata> ParameterMetadatas { get; }
        public ApiTypes ApiType { get; }
    }


}