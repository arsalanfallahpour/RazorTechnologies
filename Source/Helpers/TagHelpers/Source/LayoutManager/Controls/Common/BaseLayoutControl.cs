using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Password;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using System;
using System.IO;
using System.Threading;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public abstract class BaseLayoutControl : ILayoutControl
    {
        public BaseLayoutControl(ILayoutControlOptions options)
        {
            Options = options ?? throw new System.ArgumentNullException(nameof(options));
            Attribute = options.Attribute;

        }
        public ILayoutControlOptions Options { get; }
        public abstract IHtmlTagContent GetHtmlTagContent(IValueModel valueModel);
        public Attribute Attribute{ get; }
        public ILayoutString GenerateLayout(IValueModel valueModel)
        {
            var htmlTagContent = GetHtmlTagContent(valueModel);

            if(!htmlTagContent.IsValid())
                throw new InvalidLayoutContentException();

            return new LayoutString(htmlTagContent.Content);
        }
    }
}