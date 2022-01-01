using System;
using System.IO;
using System.Net.Http;
using System.Text;

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

using RazorTechnologies.TagHelpers.LayoutManager.Controls.HtmlForm;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Password;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Html.Form
{
    public class HtmlForm : IHtmlForm
    {
        // use IArgumentMetadata argumentMetadata in builder of this class
        public HtmlForm(IHtmlTagForm htmlTag, IHtmlFormOptions options)
        {
            HtmlTag = htmlTag;
            Options = options;
        }

        public IHtmlTagForm HtmlTag { get; }
        public IHtmlFormOptions Options { get; }

        public ILayoutString GenerateLayout()
        {
            if (HtmlTag is null)
                throw new InvalidLayoutContentException();

            string content = RenderHtmlTag(HtmlTag).SignTag(out var signed);
            if (!signed)
                throw new InvalidDataException(nameof(signed));
            return new LayoutString(content);
        }

    }
}
