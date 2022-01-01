using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.TagHelpers;

using RazorTechnologies.TagHelpers.Core.Ui.Utilities;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Generator.Output
{
    public struct HtmlOutput
    {
        private LayoutString layoutString;

        public HtmlOutput(LayoutString layoutString)
        {
            this.layoutString = layoutString ?? throw new ArgumentNullException(nameof(HtmlOutput.layoutString));

            if (!this.layoutString.HasValue())
                throw new InvalidDataException(nameof(HtmlOutput.layoutString));
        }
        public HtmlOutput()
        {
            layoutString = null;
        }
        public bool SetValue(HtmlTagAttrId layoutFotmId, string propertyFullName, string value)
        {

            if (layoutFotmId is null)
                return false;
            if (!layoutFotmId.HasValue())
                return false;
            if (string.IsNullOrEmpty(propertyFullName))
                return false;
            var formIndex = layoutString.Content.IndexOf($"<{HtmlTagForm.FormSignPattern}{HtmlTagForm.FormSignPattern}");
            var indexedContent = layoutString.Content.SkipWhile((x, i) => i == formIndex);
            var formLastIndex = indexedContent.ToString().IndexOf("</form>");
            var formContent = indexedContent.Take(formLastIndex - formIndex).ToString();
            //var attrStartIndex = 
            //((o=>$"{layoutFotmId.AttributeName}=\'{layoutFotmId.Content}\'");
            var span = layoutString.Content.AsSpan();
            //Layout HeaderData
            return true;
        }
        public override string ToString()
        {
            return layoutString.UnSignLayout(out _).ToString();
        }
    }
}
