using System;

using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls
{
    public class GridControl : BaseLayoutControl
    {
        public GridControl(ILayoutCollectionControlOptions options)
            : base(options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            Attribute = (GridControlVMAttribute)options.Attribute;
            Options = options;
        }
        public new GridControlVMAttribute Attribute { get; set; }
        public new ILayoutCollectionControlOptions Options { get; }

        public override IHtmlTagContent GetHtmlTagContent(IValueModel valueModel)
        {
            return new HtmlTagContent(string.Empty);
        }
    }
}
