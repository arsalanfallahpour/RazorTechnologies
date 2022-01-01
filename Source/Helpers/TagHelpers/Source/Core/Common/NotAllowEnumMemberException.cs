using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.Common
{
    public class NotAllowEnumMemberException : Exception
    {
        public NotAllowEnumMemberException() 
            : base($"Enumeration memeber not allowed for this method state")
        {
        }
    }
}
