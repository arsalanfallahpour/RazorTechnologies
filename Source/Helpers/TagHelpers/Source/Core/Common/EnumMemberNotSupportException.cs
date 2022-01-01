using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.Common
{
    public class EnumMemberNotSupportException : Exception
    {
        public EnumMemberNotSupportException() : base($"Enumeration memeber not support for this method>")
        {
        }
    }
}
