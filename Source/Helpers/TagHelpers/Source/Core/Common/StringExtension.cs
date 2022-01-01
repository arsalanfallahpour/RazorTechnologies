using System;
using System.Collections.Generic;
using System.Text;

namespace RazorTechnologies.Core
{
    public static  class StringExtension
    {
        public static string FromPascalToCamelCase(this string input)
        {
            return input.Remove(0, 1).Insert(0, input[0].ToString().ToLower());
        }
    }
}
