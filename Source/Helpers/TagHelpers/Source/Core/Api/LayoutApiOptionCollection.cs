using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Extensions.Options;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Models;

namespace RazorTechnologies.TagHelpers.Core.Api
{
    public class LayoutApiOptionCollection : ILayoutApiOptionCollection
    {
        public LayoutApiOptionCollection()
        {
            _apiOptions = new();
        }

        public IReadOnlyList<ILayoutApiOption> LayoutApiOptions => _apiOptions;

        public int Count => _apiOptions.Count;

        private List<LayoutApiOption> _apiOptions;

        public IEnumerator<ILayoutApiOption> GetEnumerator()
            => _apiOptions.GetEnumerator();

        public bool AddApiOptions(LayoutApiOption option)
        {
            _apiOptions.Add(option);
            return true;
        }

        public bool AddApiOptions(IEnumerable<LayoutApiOption> options)
        {
            _apiOptions.AddRange(options);
            return true;
        }
        IEnumerator IEnumerable.GetEnumerator()
            => _apiOptions.GetEnumerator(); 
    }
}