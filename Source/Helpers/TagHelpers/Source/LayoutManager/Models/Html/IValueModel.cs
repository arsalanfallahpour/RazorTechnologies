using System;
using System.Runtime.Serialization;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public interface IValueModel
    {
        public string ToString()
        {
            if(!HasValue())
                throw new ArgumentNullException(nameof(Content));
            return Content;
        }
        public bool IsNullOrEmpty()
        {
            if(Content is null)
                return true;

            return false;
        }
        public bool HasValue()
        {
            if(IsNullOrEmpty())
                return false;

            if(string.IsNullOrEmpty(Content.Trim()))
                return false;

            return true;
        }
        public int Length => ToString().Length;
        public string Content { get; }
    }
}