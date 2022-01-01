using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTechnologies.Core.Common;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.Core.THelper;
using RazorTechnologies.TagHelpers.Core.ViewModel;
using RazorTechnologies.TagHelpers.LayoutManager;
using RazorTechnologies.TagHelpers.LayoutManager.Generator;

namespace RazorTechnologies.TagHelpers.Core
{
    public abstract class BaseRequestTagHelper : BaseAppTagHelper, IRequestTagHelper
    {
        protected BaseRequestTagHelper(ILayoutManager layoutManager) 
            : base(layoutManager)
        {
        }

    }
}