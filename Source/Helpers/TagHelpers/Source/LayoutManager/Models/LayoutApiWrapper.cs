using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models
{
    public class LayoutApiWrapper : ILayoutApiWrapper
    {
        public LayoutApiWrapper()
        {
        }
        public bool AddLayoutApi(LayoutApiModel layoutApiModel)
        {
            if (layoutApiModel is null)
                throw new ArgumentNullException(nameof(layoutApiModel));

            if (_layoutApis.Any(o => o.BindingApiOption == layoutApiModel.BindingApiOption && o.HttpMethod == layoutApiModel.HttpMethod))
                return false;
            
            _layoutApis.Add(layoutApiModel);
            return true;    
        }

        public IEnumerator<LayoutApiModel> GetEnumerator()
            => _layoutApis.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => _layoutApis.GetEnumerator();

        public IReadOnlyList<LayoutApiModel> LayoutApis => _layoutApis;
        private readonly List<LayoutApiModel> _layoutApis = new();
    }
}
