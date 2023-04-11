using System;

namespace Eddy.Core.Attributes;

[AttributeUsage(validOn: AttributeTargets.Property, AllowMultiple = false)]
public class PositionAttribute : Attribute
{
    public int Position { get; set; }

    public PositionAttribute(int position)
    {
        Position = position;
    }
}