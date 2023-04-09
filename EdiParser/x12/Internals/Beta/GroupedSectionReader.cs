using System.Linq;
using EdiParser.x12.Models;
using Microsoft.Extensions.Logging;

namespace EdiParser.x12.Internals.Beta;

public class GroupedSectionReader
{
    private readonly ILogger<GroupedSectionReader> _logger;
    private readonly EdiX12Segment[] _segments;
    private Group _root;
    private int _depth;
    private int _groupDepth;

    public GroupedSectionReader(Section section, GroupingRule rule)
    {
        _segments = section.Segments.ToArray();
        _logger = Logging.Logger<GroupedSectionReader>();
        _root = new Group(null, rule);
    }

    private int CurrentLineIndex { get; set; }
    private EdiX12Segment CurrentLine => _segments[CurrentLineIndex];

    public void LogGroup(Group group)
    {
        if (group.Rule != null)
            _logger.LogDebug("".PadLeft(_groupDepth, ' ') + "+" + group.Rule.Name);
        foreach (var segment in group.Segments) _logger.LogDebug("".PadLeft(_groupDepth, ' ') + "  " + segment.GetType());

        if (group.Children.Count > 0)
        {
            _groupDepth++;
            foreach (var child in group.Children) LogGroup(child);

            _groupDepth--;
        }
    }

    public Group Read()
    {
        _depth = 0;
        _groupDepth = 0;
        Read2(_root, _root.Rule, true);
        return _root.Children[0];
    }

    public void Read2(Group parent, GroupingRule rule, bool useParentAsCurrentGroup)
    {
        Group currentGroup = null;
        if (useParentAsCurrentGroup) //true for entry so segments go into this item, false 
            currentGroup = parent;

        var prefix = "".PadLeft(_depth * 2, ' ');

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
                _depth++;
                Read2(currentGroup, matchingRule, false);
            }
            else
            {
                _logger.LogDebug("<root>");
                LogGroup(currentGroup);
                _logger.LogDebug("</root>");
                _logger.LogDebug($"{prefix}Rule no longer matches, returning");

                _depth--;
                return;
            }
        }

        _depth--;
    }
}