using RazorTechnologies.TagHelpers.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorTechnologies.TagHelpers.Core.Attr
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class BaseScopedVieModelAttribute : Attribute, IScopedVieModelAttribute
    {
        public BaseScopedVieModelAttribute(string title, string tag)
        {
            Title = title;
            Tag = tag;
        }

        public string Title { get; }
        public string Tag { get; }
    }
}
