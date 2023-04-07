using System;

namespace EdiParser.x12.Internals.Beta;

public class MatchAllGroupingRule : GroupingRule
{
    public MatchAllGroupingRule(string name, params Type[] allowedTypes) : base(name, allowedTypes)
    {
    }
    public override bool StartsWith(EdiX12Segment segment)
    {
        return false;
    }

    public override bool Matches(EdiX12Segment segment)
    {
        if (AnySubGroupStartsWith(segment)) //allow us to read until a child rule is hit
            return false;
        return true;
    }
}