using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public interface IHtmlTagAttrName : IValueModel, IHtmlTagAttributeMetadata
    {
        public IHtmlTagAttrId TranslateToIdSyntax()
            => new HtmlTagAttrId(this.ToString().Replace('.', '_'));
    }
}