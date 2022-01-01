using RazorTechnologies.TagHelpers.LayoutManager.Models;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public interface IBindingGatewayMetadata
    {
        public LayoutApiModel ApiModel { get; }
    }
}