using System;

namespace Eddy.Core.Attributes;

[AttributeUsage(validOn: AttributeTargets.Class)]
public class Segment :Attribute
{
    public string Name { get; set; }

    public Segment(string name)
    {
        Name = name;
    }
}