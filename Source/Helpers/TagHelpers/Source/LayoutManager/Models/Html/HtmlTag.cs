using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml;

using DotNetCenter.Core;

using RazorTechnologies.TagHelpers.LayoutManager.Controls.DataViewLable;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class HtmlTagModel : IHtmlTag
    {
        public HtmlTagModel(string lable)
        {
            _lable = new StringValueModel(lable);
            UniqueId = new HtmlTagAttrId($"tg_{CuidGenerator.NewCuid(7)}");
            _tagName = new HtmlTagContent("div");
        }
        public HtmlTagAttrId Id { get; private set; }
        public void SetTagId(IHtmlTagAttrId htmlTagId)
            => Id = new HtmlTagAttrId(htmlTagId.Content);
        public IHtmlTagAttrName Name => _attrName;
        private HtmlTagAttrName _attrName;
        /// <summary>
        /// Initialize HtmlTag-Attribute
        /// </summary>
        /// <param name="attrName"></param>
        public void SetName(HtmlTagAttrName attrName)
            => _attrName = attrName;
        public IHtmlTagAttrClass Class => _htmlTagClass;
        private HtmlTagAttrClass _htmlTagClass;
        public void SetTagClass(HtmlTagAttrClass htmlTagClass)
            => _htmlTagClass = htmlTagClass;
        public IHtmlTagAttrScript Script => _attrScript;
        private HtmlTagAttrScript _attrScript;
        public IHtmlTagAttrStyle Style => _attrStyle;
        private HtmlTagAttrStyle _attrStyle;
        public void SetTagScript(HtmlTagAttrScript htmlTagScript)
            => _attrScript = htmlTagScript;
        public IHtmlTagContent Content => _attrContent;
        private HtmlTagContent _attrContent;
        public void SetTagContent(HtmlTagContent htmlTagContent)
            => _attrContent = htmlTagContent;
        public IStringValueModel Lable => _lable;
        protected readonly StringValueModel _lable;
        public HtmlTagAttrId UniqueId { get; }
        public IHtmlTagContent TagName => _tagName;
        private HtmlTagContent _tagName;
        /// <summary>
        /// Initialize HtmlTag-Name
        /// </summary>
        /// <param name="tagName"></param>
        public void SetTagName(HtmlTagContent tagName)
            => _tagName = tagName;
        public virtual IDictionary<IHtmlTagAttributeMetadata, IValueModel> GetAttribute()
        {
            var attrs = new Dictionary<IHtmlTagAttributeMetadata, IValueModel>();
            if (Id is not null)
                attrs.Add(Id, Id);
            if (Name is not null)
                attrs.Add(Name, Name);
            if (Style is not null)
                attrs.Add(Style, Style);
            if (Script is not null)
                attrs.Add(Script, Script);
            return attrs;
        }

        public virtual IList<IValueModel> GetAttributesValueModel()
        {
            var set = new List<IValueModel>();
            if (Id is not null)
                set.Add(Id);
            if (Name is not null)
                set.Add(Name);
            if (Style is not null)
                set.Add(Style);
            if (Script is not null)
                set.Add(Script);
            return set;
        }

        public static bool operator ==(HtmlTagModel htmlTag1, IHtmlTag htmlTag2)
        {
            if (htmlTag1 is null)
                throw new ArgumentNullException(nameof(htmlTag1));

            if (htmlTag2 is null)
                throw new ArgumentNullException(nameof(htmlTag2));


            var id1 = htmlTag1?.Id;
            var id2 = htmlTag2?.Id;
            if (id1 is null || id2 is null)
                return false;

            return id1 == id2;
        }
        public static bool operator !=(HtmlTagModel htmlTag1, IHtmlTag htmlTag2)
        {
            if (htmlTag1 is null)
                throw new ArgumentNullException(nameof(htmlTag1));

            if (htmlTag2 is null)
                throw new ArgumentNullException(nameof(htmlTag2));


            var id1 = htmlTag1?.Id;
            var id2 = htmlTag2?.Id;
            if (id1 is null || id2 is null)
                return false;
            return id1 != id2;

        }
    }
}