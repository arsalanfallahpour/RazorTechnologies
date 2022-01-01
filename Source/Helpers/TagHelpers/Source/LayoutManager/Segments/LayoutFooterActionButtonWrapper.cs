using System.Collections.Generic;
using DotNetCenter.Core;
using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.SubmitButton;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager
{
    public class LayoutFooterActionButtonWrapper : ILayoutFooterActionButtonWrapper
    {
        public List<ILayoutSubmitButton> ActionButtons { get;} = new List<ILayoutSubmitButton>();

        public bool Disabled => throw new System.NotImplementedException();
        public void BuildActionButtons(LayoutTypes layoutType, IHtmlTagAttrId formId)
        {
            if (layoutType == LayoutTypes.JustReadable)
                return;

            ActionButtons.Add(NewSubmitButton(formId));
        }

        private ILayoutSubmitButton NewSubmitButton(IHtmlTagAttrId formId)
        {
            var id = new HtmlTagAttrId($"sid_{formId.Content}");
            HtmlTagAttrName tagName = new(id.Content);
            var options = new ButtonOptions(formId, id, new HtmlTagAttrId(CuidGenerator.NewCuid()), tagName);
            return new LayoutSubmitButton(options);
        }


        public ILayoutString GetLayoutString()
        {
            //??
            return GetSubmitButton().GetLayoutString();
        }

        private ILayoutSubmitButton GetSubmitButton()
        {
            return ActionButtons[0];
        }

        public bool SaveLayoutFile()
        {
            throw new System.NotImplementedException();
        }
    }
}
