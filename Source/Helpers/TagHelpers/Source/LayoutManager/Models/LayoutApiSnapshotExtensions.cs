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
    public static class LayoutApiSnapshotExtensions
    {
        public static LayoutApiPropertySnapshot GetBindedProperty(this LayoutApiParameterSnapshot parameter, string targetPropertyName)
        {
            return parameter
                                ?.FirstOrDefault(o => o?.Name == targetPropertyName);
        }
    }
}