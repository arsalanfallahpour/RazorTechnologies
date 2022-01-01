
using System.Collections.Generic;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public class BindingViewModelMemberOption : IBindingViewModelMemberOption
    {
        public BindingViewModelMemberOption(string modelName, string memberName)
        {
            ModelName = modelName;
            MemberName = memberName;
        }

        public string ModelName { get; }
        public string MemberName { get; }
    }
}