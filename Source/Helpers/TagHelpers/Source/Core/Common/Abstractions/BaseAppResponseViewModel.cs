using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using RazorTechnologies.TagHelpers.Core.Annotations;

namespace RazorTechnologies.TagHelpers.Core
{
    [Serializable]
    public class BaseAppResponseViewModel
    {
        [IgnoredFieldVM]
        public string ReturnUrl { get; set; }
        public BaseAppResponseViewModel() {
            IsModelValid = true;
            IsSuccessful = IsModelValid;
        }
        public BaseAppResponseViewModel(string returnUrl)
        {
            ReturnUrl = returnUrl;
            IsModelValid = true;
            IsSuccessful = IsModelValid;
        }
        [IgnoredFieldVM]
        public bool IsModelValid { get; set; }
        [IgnoredFieldVM]
        public bool IsSuccessful { get; private set; } 
        [IgnoredFieldVM]
        public string[] BusinessErrorMessages { get; set; }
        [IgnoredFieldVM]
        public ModelStateRsVm ModelState { get; set; }

        //Usage
        //var successful = IsSuccessful<TAppResponseViewModel>(new Func<TAppResponseViewModel, bool>((arg) =>
        //{
        //    return arg.IsModelValid;
        //}));
        //successful = IsSuccessful<TAppResponseViewModel>(o => o.IsModelValid);
        //); 
        public void MakeResult<TResponse>(ref TResponse response, Func<TResponse, bool> predicate)
            where TResponse : BaseAppResponseViewModel, new()
        {
            response.IsSuccessful = predicate(response);
        }
    }
}