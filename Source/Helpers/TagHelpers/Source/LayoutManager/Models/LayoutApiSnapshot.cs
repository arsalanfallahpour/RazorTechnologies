using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using static RazorTechnologies.TagHelpers.LayoutManager.Models.LayoutApiSnapshot;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models
{
    public class LayoutApiSnapshot : IReadOnlyList<LayoutApiParameterSnapshot>
    {
        private readonly List<LayoutApiParameterSnapshot> _parameters = new();
        public BindingApiOption BindingApiOption { get; }

        public LayoutApiSnapshot(BindingApiOption bindingApiOption)
        {
            BindingApiOption = bindingApiOption;
        }

        public LayoutApiParameterSnapshot this[int index] =>_parameters[index];

        public int Count => _parameters.Count;

        public bool Add(LayoutApiDataParameter layoutApiParameter)
        {
            if (layoutApiParameter is null)
                throw new ArgumentNullException(nameof(layoutApiParameter));

            if (_parameters.Any(o => o == layoutApiParameter))
                return false;
            var dataProperties = layoutApiParameter.DataProperties
                    //.Where(o => !o.IsCustomIgnored)
                    .ToArray();

            var parameter = new LayoutApiParameterSnapshot(layoutApiParameter.ApiParameterRquestViewModelType, layoutApiParameter.ApiParameterName, layoutApiParameter.IsSupportViewModel, layoutApiParameter.IsValueType);
            for (int i = 0; i < dataProperties.Length; i++)
                parameter.AddProperty(dataProperties[i]);

            _parameters.Add(parameter);
            return true;    
        }

        public IEnumerator<LayoutApiParameterSnapshot> GetEnumerator()
                => _parameters.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
                => _parameters.GetEnumerator();

        public class LayoutApiParameterSnapshot : IReadOnlyList<LayoutApiPropertySnapshot>
        {
            private readonly List<LayoutApiPropertySnapshot> _properties = new();

            public LayoutApiParameterSnapshot(Type apiParameterRquestViewModelType, string name, bool isSupportViewModel, bool isValueType)
            {
                ApiParameterRquestViewModelType = apiParameterRquestViewModelType;
                Name = name;
                IsSupportViewModel = isSupportViewModel;
                IsValueType = isValueType;
            }

            public Type ApiParameterRquestViewModelType { get; }
            public string Name { get; }
            public bool IsSupportViewModel { get; set; }
            public bool IsValueType { get; set; }

            public int Count => _properties.Count;

            public LayoutApiPropertySnapshot this[int index] => _properties[index];

            public bool AddProperty(ApiDataProperty dataProperty)
            {
                if (dataProperty is null)
                    throw new ArgumentNullException(nameof(dataProperty));
                if (_properties.Any(o => o == dataProperty))
                    return false;
                _properties.Add(new (dataProperty.BindingName, dataProperty.Name, dataProperty.UiControl?.Options?.HtmlTag?.UniqueId, dataProperty.IsCustomIgnored, dataProperty.IsCustomIgnoredBinding, dataProperty.ControlType, dataProperty.UiInputControlType));
                return true;
            }

            public IEnumerator<LayoutApiPropertySnapshot> GetEnumerator()
                => _properties.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator()
                => _properties.GetEnumerator();

            public static bool operator ==(LayoutApiParameterSnapshot obj1, LayoutApiParameterSnapshot obj2)
                => obj1.Name == obj2.Name;
            public static bool operator !=(LayoutApiParameterSnapshot obj1, LayoutApiParameterSnapshot obj2)
                 => obj1.Name == obj2.Name;

            public static bool operator ==(LayoutApiParameterSnapshot obj1, LayoutApiDataParameter obj2)
                => obj1.Name == obj2.ApiParameterName;
            public static bool operator !=(LayoutApiParameterSnapshot obj1, LayoutApiDataParameter obj2)
                 => obj1.Name == obj2.ApiParameterName;

        }
        public class LayoutApiPropertySnapshot
        {
            public LayoutApiPropertySnapshot(string bindingName,
                                             string name,
                                             HtmlTagAttrId uiControlId,
                                             bool isCustomIgnored,
                                             bool isIgnoredBinding,
                                             LayoutControlType layoutControlType,
                                             UiInputControlTypes uiInputControlType)
                : this(bindingName, name, uiControlId, isCustomIgnored, isIgnoredBinding, layoutControlType)
            {
             

                UiInputControlType = uiInputControlType;
            }

            public LayoutApiPropertySnapshot(string bindingName,
                                             string name,
                                             HtmlTagAttrId uiControlId,
                                             bool isCustomIgnored,
                                             bool isIgnoredBinding,
                                             LayoutControlType layoutControlType)
            {
                if (string.IsNullOrEmpty(bindingName))
                    throw new ArgumentException($"'{nameof(bindingName)}' cannot be null or empty.", nameof(bindingName));

                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));

                if (uiControlId is not null && uiControlId.HasValue())
                    UiControlId = uiControlId;

                BindingName = bindingName;
                Name = name;
                IsCustomIgnored = isCustomIgnored;
                IsIgnoredBinding = isIgnoredBinding;

                LayoutControlType = layoutControlType ?? throw new ArgumentNullException(nameof(layoutControlType));
            }

     

            public string BindingName { get; }
            public HtmlTagAttrId UiControlId { get; set; }
            public string Name { get; }
            public bool IsCustomIgnored { get; set; }
            public bool IsIgnoredBinding { get; }
            public LayoutControlType LayoutControlType { get; }
            public UiInputControlTypes UiInputControlType { get; }

            public static bool operator ==(LayoutApiPropertySnapshot obj1, LayoutApiPropertySnapshot obj2)
    => obj1.Name == obj2.Name;
            public static bool operator !=(LayoutApiPropertySnapshot obj1, LayoutApiPropertySnapshot obj2)
                 => obj1.Name == obj2.Name;

            public static bool operator ==(LayoutApiPropertySnapshot obj1, ApiDataProperty obj2)
                => obj1.Name == obj2.Name;
            public static bool operator !=(LayoutApiPropertySnapshot obj1, ApiDataProperty obj2)
                 => obj1.Name == obj2.Name;
        }
    }
}