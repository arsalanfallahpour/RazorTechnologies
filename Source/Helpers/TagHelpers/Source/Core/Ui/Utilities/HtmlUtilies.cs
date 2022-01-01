using System;
using System.Linq;
using System.Text;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.Core.Ui.Utilities
{
    public static class HtmlUtilies
    {
        #region Html
        public static string RenderHtmlElementDisabledAttribute(bool enabled)
    => !enabled ? "disabled" : string.Empty;
        public static string RenderHtmlElementCheckedAttribute(bool isChecked)
            => isChecked ? "checked" : string.Empty;

        public static LayoutString UnSignLayout(this LayoutString layout, out bool unSigned)
        {
            unSigned = false;
            if (string.IsNullOrEmpty(layout.Content) || !layout.HasValue())
                throw new ArgumentException($"'{nameof(layout)}' cannot be null or empty.", nameof(layout));

            var unSignedContent = layout.Content.Replace($"{HtmlTagForm.Sign}", String.Empty);
            unSigned = !layout.Content.Contains(HtmlTagForm.Sign);
            if (!unSigned)
                throw new Exception();
            return new (unSignedContent);
        }
        public static string SignTag(this string htmlForm, out bool signed)
        {
            signed = false;
            if (string.IsNullOrEmpty(htmlForm))
                throw new ArgumentException($"'{nameof(htmlForm)}' cannot be null or empty.", nameof(htmlForm));

            htmlForm = htmlForm.Replace($"{HtmlTagForm.FormTagName}", $"{HtmlTagForm.FormSignPattern}");
            signed = htmlForm.Contains(HtmlTagForm.FormSignPattern);
            if (!signed)
                throw new Exception();
            return htmlForm;
        }
        public static string RenderHtmlElementAttribute(IHtmlTagAttributeMetadata metadata, IValueModel valueModel)
        {

            var sb = new StringBuilder();
            sb.Append(metadata.AttributeName);
            sb.Append(@"='");
            if (valueModel.HasValue())
                sb.Append(valueModel.Content);
            sb.Append(@"' ");
            return sb.ToString();
        }

        public static string RenderHtmlTag(IHtmlTag tag)
        {
            var sb = new StringBuilder();
            sb.Append('<');
            sb.Append(tag.TagName.ToString());
            sb.Append(' ');
            var attrs = tag.GetAttribute();
            var attrsEnum = attrs.GetEnumerator();
            while (attrsEnum.MoveNext())
                sb.Append(RenderHtmlElementAttribute(attrsEnum.Current.Key, attrsEnum.Current.Value));
            sb.Append('>');
            sb.Append(tag.Content.ToString());
            sb.Append("</");
            sb.Append(tag.TagName.ToString());
            sb.Append('>');
            return sb.ToString();
        }
        public static string RenderHtmlTag(IInputHtmlTag tag)
        {
            var sb = new StringBuilder();
            sb.Append('<');
            sb.Append(tag.TagName.ToString());
            sb.Append(' ');
            var attrs = tag.GetAttribute();
            var attrsEnum = attrs.GetEnumerator();
            while (attrsEnum.MoveNext())
                sb.Append(RenderHtmlElementAttribute(attrsEnum.Current.Key, attrsEnum.Current.Value));
            sb.Append('>');
            sb.Append(tag.Content.ToString());
            sb.Append("</");
            sb.Append(tag.TagName.ToString());
            sb.Append('>');
            return sb.ToString();
        }
        public static string RenderHtmlTag(IHtmlTagForm tag)
        {
            var sb = new StringBuilder();
            sb.Append("<form ");
            var attrs = tag.GetAttribute();
            var attrsEnum = attrs.GetEnumerator();
            while (attrsEnum.MoveNext())
                sb.Append(RenderHtmlElementAttribute(attrsEnum.Current.Key, attrsEnum.Current.Value));
            sb.Append('>');
            sb.Append(tag.Content.ToString());
            sb.Append("</form>");
            return sb.ToString();
        }
        #endregion
    }
}
