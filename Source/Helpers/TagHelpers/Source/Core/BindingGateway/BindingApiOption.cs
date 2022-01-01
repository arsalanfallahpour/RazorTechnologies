using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public class BindingApiOption : IBindingApiOption
    {
        public BindingApiOption(string controllerName, string actionName, HttpMethod httpMethod)
        {
            HttpMethod = httpMethod ?? throw new ArgumentNullException(nameof(httpMethod));

            if (string.IsNullOrEmpty(controllerName))
                throw new ArgumentException($"'{nameof(controllerName)}' cannot be null or empty.", nameof(controllerName));

            if(string.IsNullOrEmpty(actionName))
                throw new ArgumentException($"'{nameof(actionName)}' cannot be null or empty.", nameof(actionName));

            ControllerName = controllerName;
            ActionName = actionName;
        }
        public BindingApiOption(ControllerActionDescriptor controllerActionDescriptor, HttpMethod httpMethod)
        {
            if(controllerActionDescriptor is null)
                throw new ArgumentNullException(nameof(controllerActionDescriptor));

            var controllerName = controllerActionDescriptor.ControllerTypeInfo.Name;
            if (string.IsNullOrEmpty(controllerName))
                throw new ArgumentException($"'{nameof(controllerName)}' cannot be null or empty.", nameof(controllerName));

            var actionName = controllerActionDescriptor.MethodInfo.Name;
            if(string.IsNullOrEmpty(actionName))
                throw new ArgumentException($"'{nameof(actionName)}' cannot be null or empty.", nameof(actionName));

            ControllerName = controllerName;
            ActionName = actionName;
            HttpMethod = httpMethod ?? throw new ArgumentNullException(nameof(httpMethod));
        }
        public string ControllerName { get; }
        public string ActionName { get; }
        public HttpMethod HttpMethod { get; }

        public static bool operator ==(BindingApiOption option1, IBindingApiOption option2)
            => option1.ActionName == option2.ActionName && option1.ControllerName == option2.ControllerName && option1.HttpMethod == option2.HttpMethod;
        public static bool operator !=(BindingApiOption option1, IBindingApiOption option2)
            => option1.ActionName != option2.ActionName || option1.ControllerName != option2.ControllerName || option1.HttpMethod != option2.HttpMethod;
    }
}
