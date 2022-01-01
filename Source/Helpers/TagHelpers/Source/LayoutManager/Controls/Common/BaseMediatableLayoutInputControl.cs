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
    public abstract class BaseMediatableLayoutInputControl<TAttribute> : BaseMediatableLayoutControl<TAttribute>, IMediatableLayoutInputControl
        where TAttribute : Attribute, IViewModelControlAttribute
    {
        public BaseMediatableLayoutInputControl(ILayoutInputControlOptions options, IMediator mediator)
            : base(options, mediator)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public new ILayoutInputControlOptions Options { get; }
    }
}