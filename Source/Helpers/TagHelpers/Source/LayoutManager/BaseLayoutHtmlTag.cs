using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using RazorTechnologies.TagHelpers.LayoutManager.ScopeGroup;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public abstract class BaseLayoutHtmlTag : IHtmlLayoutTag
    {
        public abstract HtmlTagAttrName NewTagName();
        public abstract HtmlTagModel NewHtmlTag(HtmlTagContent htmlTagContent);
        public abstract HtmlTagAttrId NewTagId();
    }
}