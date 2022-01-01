using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml;

using DotNetCenter.Core;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.DataViewLable;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html.Form;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public class InputHtmlTag : HtmlTagModel, IInputHtmlTag
    {

        public InputHtmlTag(string lable, bool disabled)
            : base(lable)
        {
            Disabled = disabled;
        }
        public bool Disabled { get; }

        public IHtmlTagAttrForm Form => _form;
        private HtmlTagAttrForm _form;
        public void SetTagFormId(HtmlTagAttrForm fromId)
            => _form = fromId;
        public override IDictionary<IHtmlTagAttributeMetadata, IValueModel> GetAttribute()
        {
            var attrs = base.GetAttribute();
            if (_form is not null)
                attrs.Add(_form, _form);
            return attrs;   
        }
        public override IList<IValueModel> GetAttributesValueModel()
        {
            var attrs = base.GetAttributesValueModel();
            if (_form is not null)
                attrs.Add(_form);
            return attrs;
        }
    }
}