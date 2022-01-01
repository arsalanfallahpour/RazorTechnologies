using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.CommonUtilities;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.ScriptUtilities;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.UiControlUtilities;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.StyleUtilities;
using RazorTechnologies.TagHelpers.Core.Attr;

namespace RazorTechnologies.TagHelpers.Core.Ui.Utilities
{
    public static class CommonUtilities
    {
        public static string GetModelPropertyTitle(Type requestViewModelType, string propertyName)
                => AnnotationAttributeTypeProvider.GetPropertyDisplayName(requestViewModelType, propertyName);
    }
}
