using System;
using System.Reflection;

namespace Eddy.x12.Internals;

internal class DomainTypeMap
{
    public PropertyInfo Property { get; set; }

    //public int Position { get; set; }
    public Type MatchingSegmentType { get; set; }
    public bool IsListType { get; set; }
    public bool IsComplexType { get; set; }
    public Type TypeToGenerate { get; set; }
}