//using RazorTechnologies.Core.Common;
//using RazorTechnologies.TagHelpers.Core.BindingGateway;
//using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;

//namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.DataViewLable
//{
//    public class LableControlOptions : BaseControlOptions, IDataViewLableControlOptions
//    {
//        public LableControlOptions(IBindingViewModelOption bindingViewModelOption, DataViewLableVMAttribute lableControlVMAttribute, string value, TagHelperStates formState)
//            : base(bindingViewModelOption, formState)
//        {
//            if (string.IsNullOrEmpty(value))
//                throw new System.ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));

//            LableControlVMAttribute = lableControlVMAttribute;
//            Value = value;
//        }

//        public DataViewLableVMAttribute LableControlVMAttribute { get; }
//        public string Value { get; }
//    }
//}