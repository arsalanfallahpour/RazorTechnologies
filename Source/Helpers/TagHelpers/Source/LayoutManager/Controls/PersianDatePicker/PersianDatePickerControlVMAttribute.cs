using System;

using RazorTechnologies.TagHelpers.Core.Annotations;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class PersianDatePickerControlVMAttribute : BaseViewModelAttribute, IViewModelControlAttribute
    {
        public PersianDatePickerControlVMAttribute(
            PersianDatePickerViewMode viewMode = PersianDatePickerViewMode.Day,
            bool enabled = true,
            bool toolboxEnabled = true,
            bool timePickerEnabled = false,
            bool DayPickerEnabled = true,
            bool MonthPickerEnabled = true,
            bool YearPickerEnabled = true,
            bool timePickerHourEnabled = true,
            bool timePickerMinuteEnabled = true,
            bool timePickerSecondEnabled = true,
            bool timePickerMeridianEnabled = false,
            bool onlyTimePicker = false,
            bool onlySelectOnDate = false,
            bool btnSubmitEnabled = true,
            bool btnTodayEnabled = true,
            bool toolboxCalendarSwitchEnabled = false,
            bool autoClose = false,
            bool initialValue = true,
            string btnSubmitFa = "تایید",
            string btnSubmitEn = "Submit",
            string btnTodayFa = "Today",
            string btnTodayEn = "امروز",
            int timePickerStep = 1,
            int timePickerHourStep = 1,
            int timePickerMinuteStep = 1,
            int timePickerSecondStep = 1,
            bool minDate = false,
            bool maxDate = false,
            bool navigatorEnabled = true,
            bool navigatorScrollEnabled = true,
            bool observer = false,
            bool inline = false,
            int inputDelay = 800,
            bool calendarShowHint = true,
            bool gregorianCalendarShowHint = true
            )
        {
            ToolboxEnabled = toolboxEnabled;

            //if (TimePickerEnabled)
            //    ToolboxEnabled = true;

            OnlySelectOnDate = onlySelectOnDate;
            BtnSubmitEnabled = btnSubmitEnabled;
            BtnTodayEnabled = btnTodayEnabled;
            AutoClose = autoClose;
            BtnSubmitFa = btnSubmitFa;
            BtnSubmitEn = btnSubmitEn;
            BtnTodayFa = btnTodayFa;
            BtnTodayEn = btnTodayEn;
            OnlyTimePicker = onlyTimePicker;
            TimePickerEnabled = timePickerEnabled;
            TimePickerHourEnabled = timePickerHourEnabled;
            TimePickerMinuteEnabled = timePickerMinuteEnabled;
            TimePickerSecondEnabled = timePickerSecondEnabled;
            TimePickerMeridianEnabled = timePickerMeridianEnabled;
            this.DayPickerEnabled = DayPickerEnabled;
            this.MonthPickerEnabled = MonthPickerEnabled;
            this.YearPickerEnabled = YearPickerEnabled;
            TimePickerStep = timePickerStep;
            TimePickerHourStep = timePickerHourStep;
            TimePickerMinuteStep = timePickerMinuteStep;
            TimePickerSecondStep = timePickerSecondStep;
            MinDate = minDate;
            MaxDate = maxDate;
            NavigatorEnabled = navigatorEnabled;
            NavigatorScrollEnabled = navigatorScrollEnabled;
            ToolboxCalendarSwitchEnabled = toolboxCalendarSwitchEnabled;
            Observer = observer;
            Inline = inline;
            InputDelay = inputDelay;
            InitialValue = initialValue;
            CalendarShowHint = calendarShowHint;
            GregorianCalendarShowHint = gregorianCalendarShowHint;
            ViewMode = viewMode;
            Enabled = enabled;
        }

        public bool OnlySelectOnDate { get; }
        public bool AutoClose { get; }
        public string BtnSubmitFa { get; }
        public string BtnSubmitEn { get; }
        public string BtnTodayFa { get; }
        public string BtnTodayEn { get; }
        public bool OnlyTimePicker { get; }
        public bool TimePickerEnabled { get; }
        public bool TimePickerHourEnabled { get; }
        public bool TimePickerMinuteEnabled { get; }
        public bool TimePickerSecondEnabled { get; }
        public bool TimePickerMeridianEnabled { get; }
        public bool DayPickerEnabled { get; }
        public bool MonthPickerEnabled { get; }
        public bool YearPickerEnabled { get; }
        public int TimePickerStep { get; }
        public int? TimePickerHourStep { get; }
        public int? TimePickerMinuteStep { get; }
        public int? TimePickerSecondStep { get; }
        public bool MinDate { get; }
        public bool MaxDate { get; }
        public bool NavigatorEnabled { get; }
        public bool NavigatorScrollEnabled { get; }
        public bool ToolboxEnabled { get; }
        public bool ToolboxCalendarSwitchEnabled { get; }
        public bool Observer { get; }
        public bool Inline { get; }
        public int InputDelay { get; }
        public bool InitialValue { get; }
        public bool CalendarShowHint { get; }
        public PersianDatePickerViewMode ViewMode { get; }
        public bool Enabled { get; }
        public bool GregorianCalendarShowHint { get; }
        public bool BtnTodayEnabled { get; internal set; }
        public bool BtnSubmitEnabled { get; internal set; }

        public const string Lable = "تاریخ شمسی";
    }
    public enum PersianDatePickerViewMode
    {
        Day,
        Month,
        Year
    }
}
