
using System.Text;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.PasswordBox
{
    public class PasswordBoxControl : BaseInputControl<PasswordBoxControlVMAttribute>, IAutoComletable
    {
        // use IArgumentMetadata argumentMetadata in builder of this class
        public PasswordBoxControl(ILayoutInputControlOptions options)
            : base(options)
        {
        }

        //(string tagUniqueId, string tagId, string tagName, string lable, bool comparefield)
        public override IHtmlTagContent GetHtmlTagContent(IValueModel valueModel)
        {
            var sb = new StringBuilder();
            sb.Append(" <div class='form-floating mb-3' style='position: relative;'>");
            //While Using Ajax script dont need uncommented code
            //sb.AppendFormat("<input type='text' Id='{0}' name='{1}' data-val='true' data-val-maxlength='تعداد کاراکتر ها بیشتر از حد انتظار می باشد' val-maxlength-max='100' data-val-minlength='تعداد کاراکتر ها کمتر از حد انتظار می باشد'  data-val-minlength-min='3' data-val-required='اطلاعات فیلد را وارد فرمایید' maxlength='100' value='' placeholder='...' class='form-control' {3} />", tagId, tagName, lable/*, required ? " required " : "*/);
            sb.AppendFormat("<input type='password' id='{0}' name='{1}' {3} value='' placeholder='...' class='form-control' style=''  {2} />", Options.HtmlTag.UniqueId, Options.HtmlTag.Name, $"{RenderAutoComplete()}", RenderHtmlElementAttribute(Options.HtmlTag.Form, Options.HtmlTag.Form));
            sb.AppendFormat("<label for='{0}' class='' style=''> {1} </label>", Options.HtmlTag.UniqueId, Options.HtmlTag.Lable);
            sb.Append(" </div>");
            return new HtmlTagContent(sb.ToString());
        }

        public string RenderAutoComplete()
        {
            switch (Options.RequestState)
            {
                case TagHelperStates.Create:
                    return $" autocomplete='new-password' ";

                case TagHelperStates.Update:
                    return $" autocomplete='new-password' ";
                default:
                    throw new EnumMemberNotSupportException();
            }
        }
    }
}
