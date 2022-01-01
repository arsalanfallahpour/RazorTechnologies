using System;

using RazorTechnologies.TagHelpers.LayoutManager.Controls;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class StringValueModel : BaseStringModelValue, IStringValueModel
    {
        public StringValueModel(string content)
            :base(content)
        {
        }
    }
}