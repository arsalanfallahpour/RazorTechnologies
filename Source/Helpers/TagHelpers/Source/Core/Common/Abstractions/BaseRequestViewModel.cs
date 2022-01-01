using System.ComponentModel;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using RazorTechnologies.TagHelpers.Core.Annotations;
using RazorTechnologies.TagHelpers.Core.BindingGateway;
using RazorTechnologies.TagHelpers.Core.ViewModel;

namespace RazorTechnologies.TagHelpers.Core
{
    public abstract class BaseAppRequestViewModel : BaseViewModel, IRequestViewModel
    {
        [IgnoredFieldVM]
        public abstract BaseAppResponseViewModel ResponseViewModel { get; }
    }
}
