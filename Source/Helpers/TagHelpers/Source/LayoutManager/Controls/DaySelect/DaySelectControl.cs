using System;
using System.Linq;
using System.Text;

using MediatR;

using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.DaySelect
{
    public class DaySelectControl : BaseInputControl<DaySelectControlVMAttribute>
    {
        public override UiInputControlTypes UiInputControlType => UiInputControlTypes.select;
        public DaySelectControl(ILayoutInputControlOptions options)
            : base(options)
        {
        }
        public override IHtmlTagContent GetHtmlTagContent(IValueModel valueModel)
        {
           // TODO Add Another Numeric Box For Month That Can Be Hidden And Get Value By Query And Change 31 TO 30 Based On Month
            var sb = new StringBuilder();
            sb.Append(" <div style='' class='input-group mb-4 pt-1'>");
            sb.AppendFormat($"<label for='{Options.HtmlTag.Name}' class='input-group-text' style=''> {{0}} </label>", Options.HtmlTag.Lable);
            //While Using Ajax script dont need uncommented code
            sb.Append($"<select id='{Options.HtmlTag.UniqueId}' name='{Options.HtmlTag.Name}' title=''  style='' class='form-select' {RenderHtmlElementDisabledAttribute(!Options.ForceDisabled)}>");
            sb.Append($"<option value=''>انتخاب روز ماه ...</option>");

            for (int i = 1; i <= 31; i++)
                sb.AppendFormat("<option value='{0}'>{1}</option>", i, i);

            sb.Append("</select>");
            sb.Append(" </div>");
            return new HtmlTagContent(sb.ToString());
        }
    }
}
