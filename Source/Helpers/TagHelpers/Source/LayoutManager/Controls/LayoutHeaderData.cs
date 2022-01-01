using System.Collections.Generic;
using System.Linq;

using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls
{
    public class LayoutHeaderData : ILayoutHeaderData
    {
        public LayoutHeaderData()
        {
            _tagName = new HtmlTagContent("div");
        }
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
        public string Title { get; }
        public string SubTitle { get; }
        public string Description { get; }
        public HtmlTagAttrId Id { get; private set; }
        public void SetTagId(IHtmlTagAttrId htmlTagId)
            => Id = new HtmlTagAttrId(htmlTagId.Content);
        public IHtmlTagAttrName Name => _htmlTagName;
        private HtmlTagAttrName _htmlTagName;
        public void SetName(HtmlTagAttrName htmlTagName)
            => _htmlTagName = htmlTagName;
        public IHtmlTagAttrClass Class => _htmlTagClass;
        private HtmlTagAttrClass _htmlTagClass;
        public void SetTagClass(HtmlTagAttrClass htmlTagClass)
            => _htmlTagClass = htmlTagClass;
        public IHtmlTagAttrScript Script => _htmlTagScript;
        private HtmlTagAttrScript _htmlTagScript;
        public void SetTagScript(HtmlTagAttrScript htmlTagScript)
            => _htmlTagScript = htmlTagScript;
        public IHtmlTagAttrStyle Style => _htmlTagStyle;
        private HtmlTagAttrStyle _htmlTagStyle;
        public IHtmlTagContent Content => _htmlTagContent;
        private HtmlTagContent _htmlTagContent;
        public void SetTagContent(HtmlTagContent htmlTagContent)
            => _htmlTagContent = htmlTagContent;

        public IStringValueModel Lable => _lable;
        protected readonly StringValueModel _lable;
        public HtmlTagAttrId UniqueId { get; }

        public IHtmlTagContent TagName => _tagName;

        public IReadOnlyCollection<IBindingViewModelMemberOption> Data => _data.AsReadOnly();
        protected readonly List<BindingViewModelMemberOption> _data = new();

        public void SetHeaderData(BindingViewModelMemberOption data)
            => _data.Add( data);
        public void SetHeaderData(IEnumerable<BindingViewModelMemberOption> data)
            => _data.AddRange(data);

        private HtmlTagContent _tagName;
        /// <summary>
        /// Initialize HtmlTag-Name
        /// </summary>
        /// <param name="tagName"></param>
        public void SetTagName(HtmlTagContent tagName)
            => _tagName = tagName;

        public ILayoutString GetLayoutString()
            => throw new System.NotImplementedException();
        //?????
            //=> Generator.GenerateLayout(Options);
    }
}