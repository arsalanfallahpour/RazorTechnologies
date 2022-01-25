using System;

using Microsoft.Extensions.Options;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public abstract class BaseInputControl<TAttribute> : BaseLayoutControl, ILayoutInputControl
        where TAttribute : Attribute, IViewModelControlAttribute
    {
        public BaseInputControl(ILayoutInputControlOptions options)
            : base(options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            Options = options;
            Attribute = (TAttribute)options.Attribute;
        }

        public new TAttribute Attribute { get; set; }
        public new ILayoutInputControlOptions Options { get; }
        public abstract UiInputControlTypes UiInputControlType { get; }

    }
}