using RazorTechnologies.TagHelpers.LayoutManager.Controls.Attributes;
using RazorTechnologies.TagHelpers.LayoutManager.Controls.Common;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.DataViewLable
{
    public interface IDataViewLableControlOptions : ILayoutControlOptions
    {
        public DataViewLableVMAttribute LableControlVMAttribute { get; }
        string Value { get; }
    }
}