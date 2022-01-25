using System.Text;

using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.EmailBox
{
    public class EmailBoxControl : BaseInputControl<EmailBoxControlVMAttribute>
    {
        // use IArgumentMetadata argumentMetadata in builder of this class
        public override UiInputControlTypes UiInputControlType => UiInputControlTypes.email;
        public EmailBoxControl(ILayoutInputControlOptions options)
            : base(options)
        {
        }

        //public static string GetHtmlRequestFormTextFieldContent(string tagUniqueId, string tagId, string tagName, string lable, bool required, bool disabled, string initialValue)
        public override IHtmlTagContent GetHtmlTagContent(IValueModel valueModel)
        {
            var sb = new StringBuilder();
            sb.Append(" <div class='form-floating mb-3' style='position: relative;'>");
            sb.AppendFormat("<input type='text' id='{0}' name='{1}' value='{2}' {4} placeholder='...' class='form-control' style='' {3}/>", Options.HtmlTag.UniqueId, Options.HtmlTag.Name, valueModel.Content, RenderHtmlElementDisabledAttribute(!Options.ForceDisabled), RenderHtmlElementAttribute(Options.HtmlTag.Form, Options.HtmlTag.Form));
            sb.AppendFormat("<label for='{0}' class='' style='' > {1} </label>", Options.HtmlTag.UniqueId, Options.HtmlTag.Lable);
            sb.Append(" </div>");
            return new HtmlTagContent(sb.ToString());
        }
    }
}
