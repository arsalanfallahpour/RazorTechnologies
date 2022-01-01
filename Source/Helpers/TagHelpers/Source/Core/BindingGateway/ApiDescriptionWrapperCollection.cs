using System;
using System.Collections;
using System.Collections.Generic;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public class ApiDescriptionWrapperCollection : IApiDescriptionWrapperCollection
    {

        public readonly List<ApiDescriptionWrapper> _wrapper = new();
        public int Count => _wrapper.Count;
        public void Add(ApiDescriptionWrapper wrapper)
        {
            if(!PassedRules(wrapper))
                return;

            _wrapper.Add(wrapper);
        }
        public bool Remove(ApiDescriptionWrapper wrapper)
        {
            if(!PassedRules(wrapper))
                return false;

            return _wrapper.Remove(wrapper);
        }

        private static bool PassedRules(ApiDescriptionWrapper wrapper)
        {

            if(wrapper is null)
                return false;

            if(string.IsNullOrEmpty(wrapper.Title.Trim()))
                return false;
            return true;
        }

        public IEnumerator<ApiDescriptionWrapper> GetEnumerator()
        {
            return _wrapper.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            _wrapper.Clear();
        }
    }
}
