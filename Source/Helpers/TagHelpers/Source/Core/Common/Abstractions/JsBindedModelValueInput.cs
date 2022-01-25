using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;

using static RazorTechnologies.TagHelpers.Core.JsBindedModelValues;

namespace RazorTechnologies.TagHelpers.Core
{
    public class JsBindedModelValues : IReadOnlyList<JsBindedModelValueInput>
    {

        public JsBindedModelValues()
        {
        }
        public bool Add(JsBindedModelValueInput input)
        {

            if (input is null)
                throw new ArgumentNullException(nameof(input));

            if (BindedInfo.Any(o => o.PropertyName == input.PropertyName))
                return false;
            BindedInfo.Add(input);
            return true;
        }

        public IEnumerator<JsBindedModelValueInput> GetEnumerator()
            => BindedInfo.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => BindedInfo.GetEnumerator();

        public IList<JsBindedModelValueInput> BindedInfo => bindedInfo;

        public int Count => bindedInfo.Count;

        public JsBindedModelValueInput this[int index] => bindedInfo[index];

        private readonly List<JsBindedModelValueInput> bindedInfo = new();
        public class JsBindedModelValueInput
        {
            public JsBindedModelValueInput(Guid viewModelTypeGuid, string propertyName, string propertyValue, bool forcedDisabled)
            {
                ViewModelTypeGuid = viewModelTypeGuid;
                PropertyName = propertyName;
                PropertyValue = propertyValue;
                UiForcedDisabled = forcedDisabled;
            }
            public Guid ViewModelTypeGuid { get; }
            public string PropertyName { get; }
            public string PropertyValue { get; }
            public bool UiForcedDisabled { get; }
        }

    }
}