using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.BindingGateway
{
    public class AppFilterDescriptor : FilterDescriptor, IFilterDescriptor
    {
        public AppFilterDescriptor(IFilterMetadata filter, int filterScope) 
            : base(filter, filterScope)
        {
        }
    }
}
