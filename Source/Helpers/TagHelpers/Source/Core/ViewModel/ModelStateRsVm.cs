using Microsoft.AspNetCore.Mvc.ModelBinding;

using RazorTechnologies.TagHelpers.Core.Annotations;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RazorTechnologies.TagHelpers.Core
{
    public class ModelStateRsVm
    {

        public ModelStateRsVm(ModelStateDictionary modelState)
        {
            this.modelState = modelState;
            SetErrors();
        }
        private void SetErrors()
        {
            Errors = new Dictionary<string, IEnumerable<string>>();

            var entries = modelState.AsEnumerable().ToArray();
            for (int i = 0; i < entries.Length; i++)
            {
                var currentKey = entries[i];
                Errors.Add(currentKey.Key, currentKey.Value.Errors.Select(o => o.ErrorMessage));
            }
        }
        private ModelStateDictionary modelState;
        [IgnoredFieldVM]
        public IDictionary<string, IEnumerable<string>> Errors { get; private set; }
    }
}