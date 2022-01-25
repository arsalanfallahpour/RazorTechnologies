using System.Text;

using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.DataViewLable
{
    public class DataViewLableControl : BaseInputControl<DataViewLableVMAttribute>
    {
        // use IArgumentMetadata argumentMetadata in builder of this class
        public DataViewLableControl(ILayoutInputControlOptions options)
            : base(options)
        {
        }

        public override UiInputControlTypes UiInputControlType => UiInputControlTypes.text;


        //public static string GetHtmlRequestFormLableFieldContent(string properyName, string value, string tagUniqueId, string tagId, string tagName, string lable, string separator)
        public override IHtmlTagContent GetHtmlTagContent(IValueModel valueModel)
        {
            var sb = new StringBuilder();
            sb.Append(" <div class='input-group pt-1' style='position: relative;'>");
            sb.AppendFormat("<label for='{0}' class='input-group-text' style='border :1px #597ca9 solid;border-left:none;'> {1}{2} </label>", Options.HtmlTag.UniqueId, Options.HtmlTag.Lable, " : ");
            //While Using Ajax script dont need uncommented code
            //sb.AppendFormat("<input type='text' Id='{0}' name='{1}' data-val='true' data-val-maxlength='تعداد کاراکتر ها بیشتر از حد انتظار می باشد' val-maxlength-max='100' data-val-minlength='تعداد کاراکتر ها کمتر از حد انتظار می باشد'  data-val-minlength-min='3' data-val-required='اطلاعات فیلد را وارد فرمایید' maxlength='100' value='' placeholder='...' class='form-control' {3} />", tagId, tagName, lable/*, required ? " required " : "*/);
            sb.AppendFormat($"<input value='{valueModel.Content}' type='text' id='{{0}}' name='{{1}}' class='form-control color-secondary border border-start-0 border-success' style='' disabled />", Options.HtmlTag.UniqueId, Options.HtmlTag.Name);
            sb.Append(" </div>");
            return new HtmlTagContent(sb.ToString());
        }
    }
}
