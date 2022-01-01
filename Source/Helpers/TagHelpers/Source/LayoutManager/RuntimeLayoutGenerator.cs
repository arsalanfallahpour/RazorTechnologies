
using System;

using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Generator.Output;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public class RuntimeLayoutGenerator : IRuntimeLayoutGenerator
    {

        public RuntimeLayoutGenerator()
        {
        }
        public bool IsReadyToPresent { get; private set; }

        public bool MakeReadyToPresent(LayoutString layoutString)
        {
            IsReadyToPresent = false;
            LayoutOutput = new(layoutString);
            return IsReadyToPresent = true;
        }
        public HtmlOutput LayoutOutput { get; private set; } 
        public ILayoutString GetLayoutString()
        {
            if (!IsReadyToPresent)
                throw new Exception(nameof(LayoutString));
            return new LayoutString(LayoutOutput.ToString());
        }
    }
}