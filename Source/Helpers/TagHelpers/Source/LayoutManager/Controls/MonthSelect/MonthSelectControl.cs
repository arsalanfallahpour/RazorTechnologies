using System;
using System.Linq;
using System.Text;

using MediatR;

using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.MonthSelect
{
    //goto project
    public class MonthSelectControl : BaseInputControl<MonthSelectControlVMAttribute>
    {
        // use IArgumentMetadata argumentMetadata in builder of this class
        public override UiInputControlTypes UiInputControlType => UiInputControlTypes.select;
        public MonthSelectControl(ILayoutInputControlOptions options)
            : base(options)
        {
        }
        //(string tagUniqueId, string tagId, string tagName, string lable, bool comparefield)
        public override IHtmlTagContent GetHtmlTagContent(IValueModel valueModel)
        {
           
            var sb = new StringBuilder();
            sb.Append(" <div style='' class='input-group mb-4 pt-1'>");
            sb.AppendFormat($"<label for='{Options.HtmlTag.Name}' class='input-group-text' style=''> {{0}} </label>", Options.HtmlTag.Lable);
            //While Using Ajax script dont need uncommented code
            sb.Append($"<select id='{Options.HtmlTag.UniqueId}' name='{Options.HtmlTag.Name}' title=''  style='' class='form-select' {RenderHtmlElementDisabledAttribute(!Options.ForceDisabled)}>");
            sb.Append($"<option value=''>انتخاب ماه سال ...</option>");

            for (int i = 1; i <= 12; i++)
                sb.AppendFormat("<option value='{0}'>{1}</option>", i, i);

            sb.Append("</select>");
            sb.Append(" </div>");
            return new HtmlTagContent(sb.ToString());
        }
    }
}
