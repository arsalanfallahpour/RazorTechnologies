using System;

namespace RazorTechnologies.TagHelpers.Core.Annotations
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    internal class HyperLinkControlVMAttribute : BaseViewModelAttribute
    {
        public HyperLinkControlVMAttribute(string href, string text, HtmlLinkTargets target = HtmlLinkTargets._parent)
        {
            Href = href;
            Target = target;
            Text = text;
        }

        public string Href { get; private set; }
        public HtmlLinkTargets Target { get; private set; }
        public string Text { get; internal set; }
    }
    public enum HtmlLinkTargets
    {
        _self,
        _blank,
        _parent,
        _top,
        framename
    }
}