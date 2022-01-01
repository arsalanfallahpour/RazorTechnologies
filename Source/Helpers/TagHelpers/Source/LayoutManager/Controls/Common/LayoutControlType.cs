using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.CheckBox;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.DataViewLable;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.DaySelect;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.EmailBox;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.HiddenInput;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.MonthSelect;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.NumericBox;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.PasswordBox;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.PersianDatePicker;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.PhoneNumberBox;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Range;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.TextBox;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public class LayoutControlType : ILayoutControlType
    {

        private const int MinValue = byte.MaxValue + 1;
        private const int MaxValue = int.MaxValue - 1;

        private LayoutControlType()
        {
            Value = (byte)LayoutControlTypes.Unkown;
            Name = nameof(LayoutControlTypes.Unkown);
        }
        public LayoutControlType(Type controlType, Type attributeType, int value, string name)
        {
            ControlType = controlType ?? throw new ArgumentNullException(nameof(controlType));
            AttributeType = attributeType ?? throw new ArgumentNullException(nameof(attributeType));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));

            if (value > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(value),$"Custom LayoutControlType.Value must be grater than {MaxValue}");


            if (value <  MinValue)
                throw new ArgumentOutOfRangeException(nameof(value),$"Custom LayoutControlType.Value must be less than {MinValue}");

            Value = value;
            Name = name;

        }
        private LayoutControlType(Type controlType, Type attributeType, byte value, string name)
        {
            ControlType = controlType ?? throw new ArgumentNullException(nameof(controlType));
            AttributeType = attributeType ?? throw new ArgumentNullException(nameof(attributeType));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));

            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), $"Custom LayoutControlType.Value must be more than zero");

            Value = value;
            Name = name;

        }

        public static LayoutControlType New(ILayoutControlType current) 
            => new (current.ControlType, current.AttributeType, current.Value, current.Name);

        public Type ControlType { get; }
        public Type AttributeType { get; }
        public int Value { get; }
        public LayoutControlTypes TypedValue =>(LayoutControlTypes)Value;
        public string Name { get; }

        public static bool operator ==(LayoutControlType layoutControlType1, LayoutControlType layoutControlType2)
            => layoutControlType1.Equals(layoutControlType2);

        public static bool operator !=(LayoutControlType layoutControlType1, LayoutControlType layoutControlType2)
            => !layoutControlType1.Equals(layoutControlType2);

        public static LayoutControlType MonthSelect { get; } = new LayoutControlType(typeof(MonthSelectControl),typeof(MonthSelectControlVMAttribute), (byte)LayoutControlTypes.MonthSelect, nameof(LayoutControlTypes.MonthSelect));
        public static LayoutControlType DaySelect { get; } = new LayoutControlType(typeof(DaySelectControl),typeof(DaySelectControlVMAttribute), (byte)LayoutControlTypes.DaySelect, nameof(LayoutControlTypes.DaySelect));
        public static LayoutControlType TextBox { get; } = new LayoutControlType(typeof(TextBoxControl),typeof(TextBoxControlVMAttribute), (byte)LayoutControlTypes.TextBox, nameof(LayoutControlTypes.TextBox));
        public static LayoutControlType EmailBox { get; } = new LayoutControlType(typeof(EmailBoxControl),typeof(EmailBoxControlVMAttribute), (byte)LayoutControlTypes.EmailBox, nameof(LayoutControlTypes.EmailBox));
        public static LayoutControlType HiddenInput { get; } = new LayoutControlType(typeof(HiddenInputControl),typeof(HiddenInputControlVMAttribute), (byte)LayoutControlTypes.HiddenInput, nameof(LayoutControlTypes.HiddenInput));
        public static LayoutControlType PhoneNumberBox { get; } = new LayoutControlType(typeof(PhoneNumberBoxControl),typeof(PhoneNumberBoxControlVMAttribute), (byte)LayoutControlTypes.PhoneNumberBox, nameof(LayoutControlTypes.PhoneNumberBox));
        public static LayoutControlType CheckBox { get; } = new LayoutControlType(typeof(CheckBoxControl),typeof(CheckboxControlVMAttribute), (byte)LayoutControlTypes.CheckBox, nameof(LayoutControlTypes.CheckBox));
        public static LayoutControlType NumericBox { get; } = new LayoutControlType(typeof(NumericBoxControl),typeof(NumericBoxControlVMAttribute), (byte)LayoutControlTypes.NumericBox, nameof(LayoutControlTypes.NumericBox));
        public static LayoutControlType PersianDatePicker { get; } = new LayoutControlType(typeof(PersianDatePickerControl),typeof(PersianDatePickerControlVMAttribute), (byte)LayoutControlTypes.PersianDatePicker, nameof(LayoutControlTypes.PersianDatePicker));
        public static LayoutControlType Range { get; } = new LayoutControlType(typeof(RangeControl),typeof(RangeControlVMAttribute), (byte)LayoutControlTypes.Range, nameof(LayoutControlTypes.Range));
        public static LayoutControlType PasswordBox { get; } = new LayoutControlType(typeof(PasswordBoxControl),typeof(PasswordBoxControlVMAttribute), (byte)LayoutControlTypes.PasswordBox, nameof(LayoutControlTypes.PasswordBox));
        public static LayoutControlType ComparePasswordBox { get; } = new LayoutControlType(typeof(ComparePasswordBoxControl),typeof(ComparePasswordBoxControlVMAttribute), (byte)LayoutControlTypes.ComparePasswordBox, nameof(LayoutControlTypes.ComparePasswordBox));
        public static LayoutControlType DataViewLable { get; } = new LayoutControlType(typeof(DataViewLableControl),typeof(DataViewLableVMAttribute), (byte)LayoutControlTypes.DataViewLable, nameof(LayoutControlTypes.DataViewLable));
        public static LayoutControlType Unknown { get; } = new LayoutControlType();

        public bool Equals(LayoutControlType other)
             => Value.CompareTo(other.Value) == 0;

        public override string ToString()
            => Name;
    }
}
