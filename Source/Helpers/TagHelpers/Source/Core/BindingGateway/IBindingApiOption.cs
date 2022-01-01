using System.Net.Http;

using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public interface IBindingApiOption
    {
        public System.Net.Http.HttpMethod HttpMethod { get; }
        public string ControllerName { get; }
        public string ActionName { get; }
    }
}
