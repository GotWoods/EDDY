using System;

namespace EdiParser.Attributes;

[AttributeUsage(validOn: AttributeTargets.Property, AllowMultiple = false)]
public class SectionPositionAttribute : Attribute
{
    public int Position { get; set; }

    public SectionPositionAttribute(int position)
    {
        Position = position;
    }
}