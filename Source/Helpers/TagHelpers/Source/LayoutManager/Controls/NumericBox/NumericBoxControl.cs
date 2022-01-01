using System.Text;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;
using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.NumericBox
{
    public class NumericBoxControl : BaseInputControl<NumericBoxControlVMAttribute>
    {
        // use IArgumentMetadata argumentMetadata in builder of this class
        public NumericBoxControl(ILayoutInputControlOptions options)
            : base(options)
        {
        }

        //public static string GetHtmlRequestFormTextFieldContent(string tagUniqueId, string tagId, string tagName, string lable, bool required, bool disabled, string initialValue)
        public override IHtmlTagContent GetHtmlTagContent(IValueModel valueModel)
        {
            var widthStyle = $"width:{Attribute.Width + (Options.HtmlTag.Lable.Length * 10) + 75}px!important;";
            var sb = new StringBuilder();
            sb.AppendFormat(" <div class='input-group mb-4 pt-1' style='{0}'>", widthStyle);
            sb.AppendFormat("<label for='{0}' class='input-group-text' style=''> {1} </label>", Options.HtmlTag.UniqueId, Options.HtmlTag.Lable);
            //While Using Ajax script dont need uncommented code
            //sb.AppendFormat("<input type='text' Id='{0}' name='{1}' data-val='true' data-val-maxlength='تعداد کاراکتر ها بیشتر از حد انتظار می باشد' val-maxlength-max='100' data-val-minlength='تعداد کاراکتر ها کمتر از حد انتظار می باشد'  data-val-minlength-min='3' data-val-required='اطلاعات فیلد را وارد فرمایید' maxlength='100' value='' placeholder='...' class='form-control' {3} />", tagId, tagName, lable/*, required ? " required " : "*/);
            sb.AppendFormat("<input type='number' id='{0}' name='{1}' {9} value='{8}' placeholder='{6}...' min='{3}' max='{4}' step='{5}' class='form-control' style='' {7} />",
                            Options.HtmlTag.UniqueId,
                            Options.HtmlTag.Name,
                            widthStyle,
                            Attribute.MinValue,
                            Attribute.MaxValue,
                            Attribute.Step,
                            Attribute.Placeholder,
                            RenderHtmlElementDisabledAttribute(!Options.ForceDisabled),
                             valueModel.Content,
                             RenderHtmlElementAttribute(Options.HtmlTag.Form, Options.HtmlTag.Form));
            sb.Append(" </div>");
            return new HtmlTagContent(sb.ToString());
        }
    }
}
