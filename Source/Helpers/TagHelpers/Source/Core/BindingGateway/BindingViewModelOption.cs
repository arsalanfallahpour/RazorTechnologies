namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public class BindingViewModelOption : IBindingViewModelOption
    {
        public BindingViewModelOption(string bindingModelName, string apiParameterName)
        {
            if (string.IsNullOrEmpty(bindingModelName))
                throw new System.ArgumentException($"'{nameof(bindingModelName)}' cannot be null or empty.", nameof(bindingModelName));

            if (string.IsNullOrEmpty(apiParameterName))
                throw new System.ArgumentException($"'{nameof(apiParameterName)}' cannot be null or empty.", nameof(apiParameterName));

            BindingModelName = bindingModelName;
            ApiParameterName = apiParameterName;
        }
        public string BindingModelName { get; }
        public string ApiParameterName { get; }
    }
}