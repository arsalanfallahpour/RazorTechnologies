using MediatR;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Password;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public abstract class BaseMediatableLayoutControl<TAttribute> : BaseLayoutControl, IMediatableLayoutControl
        where TAttribute : Attribute, IViewModelControlAttribute
    {
        public BaseMediatableLayoutControl(ILayoutControlOptions options, IMediator mediator)
            : base(options)
        {
            Mediator = mediator;
            Attribute = (TAttribute)options.Attribute;
        }
        public new TAttribute Attribute { get; }
        public IMediator Mediator { get; }
    }
}