using System;

namespace EdiParser.Attributes;

[AttributeUsage(validOn: AttributeTargets.Class)]
public class Segment :Attribute
{
    public string Name { get; set; }

    public Segment(string name)
    {
        Name = name;
    }
}