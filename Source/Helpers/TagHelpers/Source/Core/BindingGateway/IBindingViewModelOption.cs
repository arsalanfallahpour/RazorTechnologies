namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public interface IBindingViewModelOption
    {
        public string BindingModelName { get; }
        public string ApiParameterName { get; }
    }
}