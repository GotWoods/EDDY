using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace EdiParser.x12.Models.Internals;

public class GroupedSectionReader
{
    private readonly EdiX12Segment[] _segments;
    private readonly ILogger<GroupedSectionReader> _logger;

    public GroupedSectionReader(Section section)
    {
        _segments = section.Segments.ToArray();
        _logger = Logging.Logger<GroupedSectionReader>();
    }

    private int CurrentLineIndex { get; set; }
    //private Group CurrentGroup { get; set; }

    private EdiX12Segment CurrentLine => _segments[CurrentLineIndex];

    // private void ReadGroup(GroupingRule rule)
    // {
    //     var isStartingElementAlreadyFound = false; //false the first time around so we 
    //     while (rule.Matches(CurrentLine)) 
    //     {
    //         _logger.LogDebug($"[{CurrentLineIndex}] {CurrentLine.GetType().ToString()} matches current rule ({rule.Name})");
    //
    //         if (isStartingElementAlreadyFound && rule.StartsWith(CurrentLine)) //we found a new starter so this is a new group
    //         {
    //             _logger.LogDebug($"starting element is already found [{CurrentLineIndex}]");
    //             var g = new Group(CurrentGroup.Parent, rule);
    //             CurrentGroup.Parent.AddChild(g);
    //             CurrentGroup = g;
    //             g.Rule = rule;
    //         }
    //
    //         _logger.LogDebug($"adding {CurrentLine.GetType()} to current group");
    //         CurrentGroup.Segments.Add(CurrentLine);
    //
    //         isStartingElementAlreadyFound = true; //once this is set, if we found another of the starter, it is a new group
    //
    //         //move to the next line in the file
    //         CurrentLineIndex++;
    //         _logger.LogDebug($"Moving to line [{CurrentLineIndex}]");
    //         if (CurrentLineIndex >_segments.Length)
    //         {
    //             _logger.LogDebug($"Hit end of file, exiting");
    //             return;
    //         }
    //
    //         if (CurrentLineIndex >= _segments.Length) //we have hit the end of file
    //             return;
    //     }
    //
    //     _logger.LogDebug($"Element {CurrentLine.GetType()} does not match rule \"{rule.Name}\"");
    //
    //     _logger.LogDebug($"[{CurrentLineIndex}] Checking for subgroup match");
    //     //we have advanced to the next segment so we check if that is the start of any subgroup
    //     foreach (var subRule in rule.SubRules)
    //     {
    //         if (subRule.StartsWith(CurrentLine))
    //         {
    //             _logger.LogDebug($"Subrule rule match to {subRule.Name}");
    //             var subGroup = new Group(this.CurrentGroup, subRule);
    //             CurrentGroup.AddChild(subGroup);
    //             CurrentGroup = subGroup;
    //             ReadGroup(subRule);
    //         }
    //     }


        //at this point there is no subgroup match and we are on stop entitiy


        // _logger.LogDebug($"[{CurrentLine}] Checking for sibling group match");
        // //if not a subgroup, it may match a sibling group
        // if (rule.Parent != null)
        //     foreach (var siblingRule in rule.Parent.SubRules)
        //     {
        //         if (siblingRule.StartsWith(segment))
        //         {
        //             _logger.LogDebug($"Sibling rule match to {siblingRule.Name}");
        //             var subGroup = new Group(CurrentGroup, siblingRule);
        //             subGroup.Rule = siblingRule;
        //             CurrentGroup.Parent.AddChild(subGroup);
        //             CurrentGroup = subGroup;
        //             ReadGroup(siblingRule);
        //             return;
        //         }
        //     }



        // else if (rule.AnySubGroupStartsWith(segment))
        // {
        //     var newRule = rule.SubGroups.First(x => x.StartsWith(segment));
        //     var subGroup = new Group();
        //     CurrentGroup.SubGroups.Add(subGroup);
        //     CurrentGroup = subGroup;
        //     GroupDepth++;
        //     isGroupDetected = true;
        //     CurrentRule = newRule;
        //     //need to shift into the newRule with a new group and keep scanning lines until we find a line that does not match
        //     //Read(section, newRule.SubGroups.ToArray());
        // }

   // }


    //this should read repeating groups
    //e.g.
    //N1
    //N3
    //N4
    //N1
    //N3
    //N4
    //and return two groups

    
    private int groupDepth = 0;
    public void LogGroup(Group group)
    {
        
        if (group.Rule != null)
            _logger.LogDebug("".PadLeft(groupDepth, ' ') + "+" + group.Rule.Name);
        foreach (var segment in group.Segments)
        {
            _logger.LogDebug("".PadLeft(groupDepth, ' ') + "  " + segment.GetType());
        }

        if (group.Children.Count > 0)
        {
        
            groupDepth++;
            foreach (var child in group.Children)
            {
                LogGroup(child);
            }

            groupDepth--;
        }

        
    }

    public Group Read(params GroupingRule[] rules)
    {
        //creating a wrapper around it all
        _root = new Group();
        var rootRule = new MatchAllGroupingRule("Root");
        rootRule.AddSubRule(rules);
        Read2(_root, rootRule, true);
        return _root;
    }
    
    private int depth = 0;
    private Group _root;

    public void Read2(Group parent, GroupingRule rule, bool useParentAsCurrentGroup)
    {
        //var groups = new List<Group>();
        Group currentGroup = null;
        if (useParentAsCurrentGroup) //true for entry so segments go into this item, false 
            currentGroup = parent;

        var prefix = "".PadLeft(depth*2, ' ');

        while (CurrentLineIndex < _segments.Length)
        {
            _logger.LogDebug($"{prefix}Processing [{CurrentLineIndex}] {CurrentLine.GetType()} against {rule.Name}");
            if (rule.StartsWith(CurrentLine))
            {
                //_logger.LogDebug($"{prefix}Rule Starts with segment, creating a new group named {rule.Name} and adding it to group {parent.Name}");
                currentGroup = new Group(parent, rule);
                parent.AddChild(currentGroup);
                currentGroup.Segments.Add(CurrentLine);
                CurrentLineIndex++;
                _logger.LogDebug($"New group created as {currentGroup.Name} and added to {parent.Name}");
            }
            else if (rule.Matches(CurrentLine))
            {
               _logger.LogDebug($"{prefix}Adding segment {CurrentLine.GetType()} to {currentGroup.Name}");
               currentGroup.Segments.Add(CurrentLine);
               CurrentLineIndex++;
            }
            else if (rule.AnySubGroupStartsWith(CurrentLine))
            {
                var matchingRule = rule.SubRules.FirstOrDefault(x => x.StartsWith(CurrentLine));
                _logger.LogDebug($"{prefix}Rule {rule.Name} matches subrule {matchingRule.Name}");
                depth++;
                Read2(currentGroup, matchingRule,false );
            }
            else
            {
                
                _logger.LogDebug("<root>");
                LogGroup(currentGroup);
                _logger.LogDebug("</root>");
                _logger.LogDebug($"{prefix}Rule no longer matches, returning");
                
                depth--;
                return;
               // return groups;
            }

            // _logger.LogDebug("<root>");
            // LogGroup(parent);
            // _logger.LogDebug("</root>");
        }
        depth--;
        //return groups;
    }

    //
    // public Group ReadOld(params GroupingRule[] groupRules)
    // {
    //    // CurrentRuleSet.Push(groupRules.ToList());
    //    
    //     for (var index = 0; index < _segments.Length; index++)
    //     {
    //         var segment = _segments[index];
    //         _logger.LogDebug($"[{index}] is type {segment.GetType().ToString()}");
    //     }
    //
    //     _logger.LogDebug("");
    //
    //     var result = new Group(null, null);
    //
    //     while (CurrentLineIndex < _segments.Length)
    //     {
    //         _logger.LogDebug($"Current line is {CurrentLineIndex}");
    //         var segment = _segments[CurrentLineIndex];
    //         //var wasMatchedToGroup = false;
    //         var isGroupDetected = false;
    //         
    //         
    //         foreach (var rule in groupRules)
    //         {
    //             if (rule.StartsWith(segment))
    //             {
    //                 _logger.LogDebug($"rule {rule.Name} matches segment");
    //                 CurrentGroup = new Group(result, rule);
    //                 result.AddChild(CurrentGroup);
    //                 isGroupDetected = true;
    //                 ReadGroup(rule);
    //                 break; //no point checking the other group rules as we already found one
    //             }
    //         }
    //
    //         if (!isGroupDetected)
    //         {
    //             _logger.LogDebug($"[{CurrentLineIndex}] adding {segment.GetType().ToString()} to plain old segments");
    //             result.Segments.Add(segment);
    //             CurrentLineIndex++;
    //         }
    //     }
    //     return result;
    // }
}