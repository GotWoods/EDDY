using System;
using System.Collections.Generic;
using System.Linq;
using Eddy.x12.Models;

namespace Eddy.x12.Internals.Beta;

public class GroupingRule
{
    private List<GroupingRule> _subRules = new();

    public string Name { get; set; }

    public GroupingRule(string name, string[] allowedTypeIdentifiers)
    {
        Name = name;
        foreach (var allowedTypeIdentifier in allowedTypeIdentifiers)
        {
            AllowedTypes.Add(EdiSectionParserFactory.GetSegmentFor(allowedTypeIdentifier));
        }
    }

    public GroupingRule(string name, string[] allowedTypeIdentifiers, List<GroupingRule> subRules)
    {
        Name = name;
        foreach (var allowedTypeIdentifier in allowedTypeIdentifiers)
        {
            AllowedTypes.Add(EdiSectionParserFactory.GetSegmentFor(allowedTypeIdentifier));
        }

        _subRules = subRules;
    }

    public GroupingRule(string name, params Type[] allowedTypes)
    {
        Name = name;
        AllowedTypes = allowedTypes.ToList();
    }

    public List<Type> AllowedTypes { get; set; } = new();

    public IReadOnlyList<GroupingRule> SubRules => _subRules.AsReadOnly();

    public void AddSubRule(GroupingRule[] rules)
    {
        foreach (var groupingRule in rules)
        {
            AddSubRule(groupingRule);
        }
    }
    public void AddSubRule(GroupingRule rule)
    {
        rule.Parent = this;
        _subRules.Add(rule);
    }

    public GroupingRule AddSubRule(string name, params string[] allowedTypes)
    {
        var groupingRule = new GroupingRule(name, allowedTypes);
        AddSubRule(groupingRule);
        return groupingRule;
    }

    public GroupingRule AddSubRule(string name, params Type[] allowedTypes)
    {
        var groupingRule = new GroupingRule(name, allowedTypes);
        AddSubRule(groupingRule);
        return groupingRule;
    }
    public GroupingRule Parent { get; set; }

    public virtual bool StartsWith(EdiX12Segment segment)
    {
        if (AllowedTypes.Count == 0)
            return false;
        return AllowedTypes.First() == segment.GetType();
    }

    public virtual bool Matches(EdiX12Segment segment)
    {
        return AllowedTypes.Any(allowedType => segment.GetType() == allowedType);
    }

    public bool AnySubGroupStartsWith(EdiX12Segment segment)
    {
        foreach (var groupingRule in SubRules)
            if (groupingRule.StartsWith(segment))
                return true;
        return false;
    }
}