using System;
using System.IO;
using System.Runtime.Serialization;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Password
{
    [Serializable]
    public class InvalidLayoutContentException : Exception
    {
        public InvalidLayoutContentException() : base(Message)
        {
        }

        public static string Message => "Generated Html Tag Result Not Valid";
    }
}