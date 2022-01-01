using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public interface IHtmlTag
    {
        public IDictionary<IHtmlTagAttributeMetadata, IValueModel> GetAttribute();
        public IList<IValueModel> GetAttributesValueModel();
        
        public HtmlTagAttrId Id { get; }
        public IHtmlTagAttrName Name { get; }
        public IHtmlTagContent TagName { get; }
        public IHtmlTagAttrClass Class { get; }
        public IHtmlTagAttrScript Script { get; }
        public IHtmlTagAttrStyle Style { get; }
        public IHtmlTagContent Content { get; }
        public IStringValueModel Lable { get; }
        public HtmlTagAttrId UniqueId { get; }
        
        public void SetTagId(IHtmlTagAttrId htmlTagId);
        public void SetTagName(HtmlTagContent htmlTagContent);
        public void SetName(HtmlTagAttrName htmlTagName);
        public void SetTagClass(HtmlTagAttrClass htmlTagClass);
        public void SetTagScript(HtmlTagAttrScript htmlTagScript);
        public void SetTagContent(HtmlTagContent htmlTagContent);
    }
}