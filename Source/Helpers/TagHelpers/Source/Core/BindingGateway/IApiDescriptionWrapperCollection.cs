using System;
using System.Collections;
using System.Collections.Generic;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public interface IApiDescriptionWrapperCollection :  IReadOnlyCollection<ApiDescriptionWrapper>, IDisposable
    {
    }
}