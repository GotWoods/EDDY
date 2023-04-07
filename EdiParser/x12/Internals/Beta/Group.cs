using System.Collections.Generic;
using System.Xml.Serialization;

namespace EdiParser.x12.Internals.Beta;

public class Group : IGroupable
{
    public Group()
    {

    }

    public Group(IGroupable parent, GroupingRule rule)
    {
        Parent = parent;
        Rule = rule;
    }

    private List<Group> _children = new();

    [XmlIgnore]
    public List<EdiX12Segment> Segments { get; set; } = new();
    public IReadOnlyList<Group> Children => _children.AsReadOnly();

    public void AddChild(Group child)
    {
        child.Parent = this;
        _children.Add(child);
    }

    public void AddChildren(List<Group> children)
    {
        foreach (var child in children)
        {
            AddChild(child);
        }
    }

    [XmlIgnore]
    public IGroupable Parent { get; set; }

    [XmlIgnore]
    public GroupingRule Rule { get; set; }


    public string Name
    {
        get
        {
            if (Rule == null)
                return "";
            var name = Rule.Name;

            var curRule = Rule;
            while (curRule.Parent != null)
            {
                name = curRule.Parent.Name + "." + name;
                curRule = curRule.Parent;
            }
            return name;
        }
    }
}