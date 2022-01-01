using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html.Form
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class HtmlTagAttrForm: HtmlTagAttrId, IHtmlTagAttrForm
    {
        public HtmlTagAttrForm(string tagId)
            :base(tagId)
        {

        }
        public HtmlTagAttrForm()
            :base()
        {
        }
        public override string AttributeName => "form";

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
