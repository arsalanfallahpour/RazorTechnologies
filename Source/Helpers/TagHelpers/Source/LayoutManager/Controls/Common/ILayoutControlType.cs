using System;

namespace RazorTechnologies.TagHelpers.LayoutManager.Controls.Common
{
    public interface ILayoutControlType : IEquatable<LayoutControlType>
    {
        public Type ControlType { get; }
        public Type AttributeType { get; }
        public int Value { get; }
        public string Name { get; }

        public bool Equals(LayoutControlType other)
             => Value.CompareTo(other.Value) == 0;

    }
}