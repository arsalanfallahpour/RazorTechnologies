using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RazorTechnologies.TagHelpers.LayoutManager.Controls;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public interface IHtmlTagForm
    {
        public IDictionary<IHtmlTagAttributeMetadata, IValueModel> GetAttribute()
        {
            var attrs = new Dictionary<IHtmlTagAttributeMetadata, IValueModel>();
            if (Id is not null && Id.HasValue())
            attrs.Add(Id, Id);
            if (Name is not null && Name.HasValue())
                attrs.Add(Name, Name);
            if (Method is not null && Method.HasValue())
                attrs.Add(Method, Method);
            if (Action is not null && Action.HasValue())
                attrs.Add(Action, Action);
                attrs.Add(Style, Style);
                attrs.Add(Script, Script);
            return attrs;
        }

        public IEnumerable<IValueModel> GetAttributesValueModel()
        => new HashSet<IValueModel>() { Id, Name, Method, Action, Class, Script };
        public IHtmlTagAttrId Id { get; }
        public IHtmlTagAttrName Name { get; }
        public IHtmlTagAttrAction Action { get; }
        public IHtmlTagAttrMethod Method { get; }
        public IHtmlTagAttrClass Class { get; }
        public IHtmlTagFormContent Content{ get; }
        public IHtmlTagAttrScript Script { get; }
        public IHtmlTagAttrStyle Style { get; }
        public IHtmlTagAttrId UniqueId { get; }
    }
}
