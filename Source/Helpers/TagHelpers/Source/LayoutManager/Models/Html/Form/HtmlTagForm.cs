using System;
using System.Diagnostics;
using System.Linq;

using DotNetCenter.Core;


using RazorTechnologies.TagHelpers.LayoutManager.Controls.Password;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class HtmlTagForm : IHtmlTagForm
    {
        #region Constructors
        public HtmlTagForm(
                           HtmlTagAttrMethod attrMethod,
                           HtmlTagAttrAction attrAction,
                           HtmlTagAttrId id,
                           HtmlTagAttrName name,
                           HtmlTagAttrClass htmlTagClass,
                           HtmlTagAttrScript htmlTagScript,
                           HtmlTagAttrStyle htmlTagStyle,
                           HtmlTagFormContent htmlTagFormContent,
                           StringValueModel lable)
        {
            UniqueId = new HtmlTagAttrId($"fr_{CuidGenerator.NewCuid()}");
            _htmlTagId = id ?? throw new ArgumentNullException(nameof(id));
            _htmlTagName = name ?? throw new ArgumentNullException(nameof(name));
            _htmlTagClass = htmlTagClass ?? throw new ArgumentNullException(nameof(htmlTagClass));
            _htmlTagScript = htmlTagScript ?? throw new ArgumentNullException(nameof(htmlTagScript));
            _htmlTagStyle = htmlTagStyle ?? throw new ArgumentNullException(nameof(htmlTagStyle));
            _htmlTagFormContent = htmlTagFormContent ?? throw new ArgumentNullException(nameof(htmlTagFormContent));
            _lable = lable ?? throw new ArgumentNullException(nameof(lable));
            _attrAction = attrAction ?? throw new ArgumentNullException(nameof(attrAction));
            _attrMethod = attrMethod;
        }
        #endregion
        #region Properties
        public IHtmlTagAttrId Id => _htmlTagId;
        private readonly HtmlTagAttrId _htmlTagId;

        public IHtmlTagAttrName Name => _htmlTagName;
        private readonly HtmlTagAttrName _htmlTagName;

        public IHtmlTagAttrClass Class => _htmlTagClass;
        private readonly HtmlTagAttrClass _htmlTagClass;

        public IHtmlTagAttrScript Script => _htmlTagScript;
        private readonly HtmlTagAttrScript _htmlTagScript;

        public IHtmlTagAttrStyle Style => _htmlTagStyle;
        private readonly HtmlTagAttrStyle _htmlTagStyle;
        public IHtmlTagFormContent Content => _htmlTagFormContent;
        private readonly HtmlTagFormContent _htmlTagFormContent;
        public IStringValueModel Lable => _lable;
        protected readonly StringValueModel _lable;
        public IHtmlTagAttrId UniqueId { get; }

        public IHtmlTagAttrAction Action => _attrAction;
        private readonly HtmlTagAttrAction _attrAction;
        public IHtmlTagAttrMethod Method => _attrMethod;
        private readonly HtmlTagAttrMethod _attrMethod;


        public readonly static string FormTagName = "<form ";


        public readonly static string FormSignPattern = $"{FormTagName}{Sign} ";
        public readonly static string Sign = "!%2%3m#f4#%!";

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        #endregion

    }
}
