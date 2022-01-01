using System;

using RazorTechnologies.TagHelpers.LayoutManager.Controls;

namespace RazorTechnologies.TagHelpers.LayoutManager.Models.Html
{
    public abstract class BaseStringModelValue : IValueModel
    {
        public BaseStringModelValue(string content)
        {
            Content = content;
        }
        public bool IsNullOrEmpty()
        {
            if(Content is null)
                return true;

            if(string.IsNullOrEmpty(Content.Trim()))
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
        public string Content { get; }
        public override string ToString()
        {
            if (!HasValue())
                return string.Empty;
            return Content.ToString();
        }
    }
}