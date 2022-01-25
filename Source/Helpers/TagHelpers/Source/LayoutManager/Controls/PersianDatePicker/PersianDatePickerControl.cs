using System;
using System.Text;

using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;
using RazorTechnologies.TagHelpers.LayoutManager.Models.Html;

using static RazorTechnologies.TagHelpers.Core.Ui.Utilities.HtmlUtilies;
namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.PersianDatePicker
{
    public class PersianDatePickerControl : BaseInputControl<PersianDatePickerControlVMAttribute>
    {
        // use IArgumentMetadata argumentMetadata in builder of this class
        public PersianDatePickerControl(ILayoutInputControlOptions options)
            : base(options)
        {
        }
        public override UiInputControlTypes UiInputControlType => UiInputControlTypes.text;
        //public static string GetHtmlRequestFormPersianDatePickerContent(string tagUniqueId, string tagId, string tagName, string lable, bool disabled, PersianDatePickerControlVMAttribute attribute)
        public override IHtmlTagContent GetHtmlTagContent(IValueModel valueModel)
        {
            var _tagIdPostfix = "_Picker";
            var _tagIdAltPostfix = $"{_tagIdPostfix}_Alt";
            var sb = new StringBuilder();
            sb.Append(" <div class='input-group mb-4 pt-1'>");
            sb.AppendFormat("<label for='{0}' class='input-group-text' style=''> {1} </label>", Options.HtmlTag.UniqueId, Options.HtmlTag.Lable);
            //sb.AppendFormat("<input type='hidden' id='{0}' name='{1}' value='' class='form-control' style=''/>", tagId, tagName, lable);
            sb.AppendFormat($"<input type='text' id='{{0}}' name='{{1}}' value='' placeholder='...' class='form-control' style='' {RenderHtmlElementDisabledAttribute(!Options.HtmlTag.Disabled)} {RenderHtmlElementAttribute(Options.HtmlTag.Form, Options.HtmlTag.Form)}/>", Options.HtmlTag.Id, Options.HtmlTag.Name);
            sb.Append(" </div>");
            sb.Append(
                "<script>$(document).ready(" +
                "(function(){" +
                        $"const datepickerDOM=$('#{Options.HtmlTag.Id}')," +
                        "dateObject=datepickerDOM.persianDatepicker(" +
                        "{" +
                        $"inline:{getBooleanPropertyContent(Attribute.Inline)}," +
                        $"format:'LLLL'," +
                        //year month day
                        $"viewMode:{getViewModePropertyContent(Attribute.ViewMode)}," +
                        $"initialValue:{getBooleanPropertyContent(Attribute.InitialValue)}," +
                        $"minDate:{getBooleanPropertyContent(Attribute.MinDate)}," +
                        $"maxDate:{getBooleanPropertyContent(Attribute.MaxDate)}," +
                        $"autoClose:{getBooleanPropertyContent(Attribute.AutoClose)}," +
                        $"position:'auto'," +
                        $"altFormat:'lll'," +
                        $"altField:'#{Options.HtmlTag.Id}{_tagIdAltPostfix}'," +
                        $"onlyTimePicker:{getBooleanPropertyContent(Attribute.OnlyTimePicker)}," +
                        $"onlySelectOnDate:{getBooleanPropertyContent(Attribute.OnlySelectOnDate)}," +
                        $"calendarType:'persian'," +
                        $"inputDelay:{Attribute.InputDelay}," +
                        $"observer:{getBooleanPropertyContent(Attribute.Observer)}," +
                        $"calendar:{{" +
                        $"persian:{{locale:'fa',showHint:{getBooleanPropertyContent(Attribute.CalendarShowHint)},leapYearMode:'algorithmic'}}," +
                        $"gregorian:{{locale:'en', showHint:{getBooleanPropertyContent(Attribute.GregorianCalendarShowHint)}}}" +
                        $"}}," +
                        $"navigator:{{" +
                        $"enabled:{getBooleanPropertyContent(Attribute.NavigatorEnabled)}" +
                        $",scroll:{{enabled:{getBooleanPropertyContent(Attribute.NavigatorScrollEnabled)}}}," +
                        $"text:{{btnNextText:'<',btnPrevText:'>'}}" +
                        $"}}," +
                        $"toolbox:{{enabled:{getBooleanPropertyContent(Attribute.ToolboxEnabled)},calendarSwitch:{{enabled:{getBooleanPropertyContent(Attribute.ToolboxCalendarSwitchEnabled)},format:'MMMM'}}," +
                        $"todayButton:{{enabled:{getBooleanPropertyContent(Attribute.BtnTodayEnabled)},text:{{fa:'{Attribute.BtnTodayFa}',en:'{Attribute.BtnTodayEn}'}}}}," +
                        $"submitButton:{{enabled:{getBooleanPropertyContent(Attribute.BtnSubmitEnabled)},text:{{fa:'{Attribute.BtnSubmitFa}',en:'{Attribute.BtnSubmitEn}'}}}}," +
                        $"text:{{btnToday:'{Attribute.BtnTodayFa}'}}}}," +
                        $"timePicker:{{enabled:{getBooleanPropertyContent(Attribute.TimePickerEnabled)},step:{Attribute.TimePickerStep}" +
                        $",hour:{{enabled:{getBooleanPropertyContent(Attribute.TimePickerHourEnabled)},step:{Attribute.TimePickerHourStep}}}" +
                        $",minute:{{enabled:{getBooleanPropertyContent(Attribute.TimePickerMinuteEnabled)},step:{Attribute.TimePickerMinuteStep}}}" +
                        $",second:{{enabled:{getBooleanPropertyContent(Attribute.TimePickerSecondEnabled)},step:{Attribute.TimePickerSecondStep}}}," +
                        $"meridian:{{enabled:{getBooleanPropertyContent(Attribute.TimePickerMeridianEnabled)}}}" +
                        $"}}," +
                        $"dayPicker:{{enabled:{getBooleanPropertyContent(Attribute.DayPickerEnabled)},titleFormat:'YYYY MMMM'}}," +
                        $"monthPicker:{{enabled:{getBooleanPropertyContent(Attribute.MonthPickerEnabled)},titleFormat:'YYYY'}}," +
                        $"yearPicker:{{enabled:{getBooleanPropertyContent(Attribute.YearPickerEnabled)},titleFormat:'YYYY'}}," +
                        $"responsive:!0," +
                        "onSelect:function(){" +
                        "var content = '';");
            if (Attribute.ViewMode == PersianDatePickerViewMode.Day)
                sb.Append("content = `${date.year}/${date.month}/${date.date}`;");
            else if (Attribute.ViewMode == PersianDatePickerViewMode.Month)
                sb.Append("content = `${date.year}/${date.month}`;");
            else if (Attribute.ViewMode == PersianDatePickerViewMode.Year)
                sb.Append("content = `${date.year}`;");
            else
                throw new Exception();
            if (Attribute.TimePickerEnabled)
                sb.Append("content += (' ~ ' + `${date.hour}:${date.minute}:${date.second}`);");
            //"alert(`تاریخ انتخاب شده : ${date.year}/${date.month}/${date.date} ~ ${date.hour}:${date.minute}:${date.second}`)" +
            sb.Append("datepickerDOM.val(content);" +
            $"if(state.viewMode === 'day' && state.model.options.timePicker.enabled === false){{" +
               $"$('#{Options.HtmlTag.Id}').val(content);" +
           $"}}");
            sb.Append("}})," +
                "state=dateObject.getState(), " +
                "date = state.view;");
            sb.Append("dateViewValue = datepickerDOM.val();");
            sb.Append("datepickerDOM.attr('placeholder', dateViewValue);");
            sb.Append("datepickerDOM.val('');");
            sb.Append("}));</script>");
            return new HtmlTagContent(sb.ToString());

            string getBooleanPropertyContent(bool isTrue)
                => isTrue ? "!0" : "!1";

            string getViewModePropertyContent(PersianDatePickerViewMode viewMode)
                => $"\'{viewMode.ToString().ToLower()}\'";
        }
    }
}
