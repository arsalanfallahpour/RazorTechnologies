using RazorTechnologies.TagHelpers.Core.Attr;
using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.Core.ViewModel;
using RazorTechnologies.TagHelpers.LayoutManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.Common.Abstractions
{
    public abstract class BaseGridControlTagHelper<TRequestViewModel> : BaseRequestTagHelper, IFormRequestTagHelper
        where TRequestViewModel : BaseAppRequestViewModel
    {
        protected BaseGridControlTagHelper(ILayoutManager layoutManager) 
            : base(layoutManager)
        {
        }
    }
}
