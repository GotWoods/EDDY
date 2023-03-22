using EdiParser.x12;
using EdiParser.x12.Models.Internals;

namespace EdiParser.Tests.x12.Beta;

public class GroupLang
{
    public static GroupingRule[] ToGroups(string pattern)
    {
        var groups = new List<GroupingRule>();

        var rootIndentation = 0; //store the base elements indentation. Everything that is +2 over the indent it a new group
        foreach (var line in pattern.Split(Environment.NewLine))
        {
            if (line.Trim() == "+++")
                continue;
            
            if (rootIndentation == 0) //first line we encounter
                rootIndentation = line.IndexOf("+");

            if (line.Substring(rootIndentation, 1) == "+")
            {

            }


            var data = line.Trim().Substring(1); //strip off the leading character
            var name = data.Substring(0, data.IndexOf("(")-1).Trim();
            var parts = data.Substring(data.IndexOf("(")+1).Trim();
            parts = parts.Substring(0, parts.Length - 1); //strip off closing )

            var allowedTypeString = parts.Split(",").Select(x=>x.Trim());
            var allowedTypes = new List<Type>();
            foreach (var allowedType in allowedTypeString)
            {
                allowedTypes.Add(EdiSectionParserFactory.GetSegmentFor(allowedType));
            }
            var rule = new GroupingRule(name, allowedTypes.ToArray());
            
            groups.Add(rule);
        }

        return groups.ToArray();
    }
}