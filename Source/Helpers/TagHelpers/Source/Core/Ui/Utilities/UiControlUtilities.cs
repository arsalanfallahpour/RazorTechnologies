using RazorTechnologies.TagHelpers.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.StyleUtilities;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.UiControlUtilities;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.ScriptUtilities;
using DotNetCenter.Core;

namespace RazorTechnologies.TagHelpers.Core.Ui.Utilities
{
    public static class UiControlUtilities
    {

        #region GetHtmlRequestFormHyperLinkContent
        public static string GetHtmlRequestFormHyperLinkContent(string tagUniqueId, string tagId, string tagName, string lable, string href, string text, HtmlLinkTargets target)
        {
            var sb = new StringBuilder();
            sb.Append(" <div class='input-group mb-4 pt-1' style='position: relative;'>");
            sb.AppendFormat("<label for='{0}' class='input-group-text' style=''> {1}: </label>", tagUniqueId, lable);
            sb.AppendFormat("<a href='{2}' targe='{3}' id='{0}' name='{1}' class='form-control' {5}>{4}</a>", tagId, tagName, href, target.ToString(), text);
            sb.Append(" </div>");
            return sb.ToString();
        }
        #endregion
        
        #region GetHtmlRequestFormPhoneFieldContent
        public static string GetHtmlRequestFormPhoneFieldContent(string tagUniqueId, string tagId, string lable)
        {
            var sb = new StringBuilder();
            sb.Append("");
            return sb.ToString();
        }
        #endregion

    }
}
