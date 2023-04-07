using System;
using System.Linq;
using System.Reflection;
using EdiParser.Attributes;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Mapping;

public class Map
{
    public static EdiX12Segment MapObject(Type t, string line, MapOptions options)
    {
        var values = line.Split(options.Separator.ToCharArray())
            .Select(x => x.Trim())
            .ToList();

        var result = (EdiX12Segment)Activator.CreateInstance(t);

        var props = result.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(PositionAttribute)));
        foreach (var propertyInfo in props)
        {
            var position = propertyInfo.GetCustomAttribute<PositionAttribute>().Position;
            if (values.Count > position)
            {
                var propertyValue = values[position];
                if (propertyValue.Trim().Length > 0)
                {
                    var underlyingType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                    var safeValue = propertyValue == null ? null : Convert.ChangeType(propertyValue, underlyingType);
                    propertyInfo.SetValue(result, safeValue, null);
                }
            }
        }

        if (options.PerformValidations) result.ValidationResult = result.Validate();

        return result;
    }

    public static T MapObject<T>(string line, MapOptions options) where T : new()
    {
        var segment = MapObject(typeof(T), line, options);
        return (T)Convert.ChangeType(segment, typeof(T));
        ;
    }

    public static string SegmentToString<T>(T segment, MapOptions options) where T : EdiX12Segment
    {
        var segmentType = segment.GetType().GetCustomAttribute<Segment>();

        var props = segment.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(PositionAttribute))).ToList();
        var data = new string[props.Max(x => x.GetCustomAttribute<PositionAttribute>().Position) + 1];

        //there is no gaurantee the properties will be in order in the class so we dump the values into an array 
        foreach (var propertyInfo in props)
        {
            var position = propertyInfo.GetCustomAttribute<PositionAttribute>().Position;
            var propertyValue = propertyInfo.GetValue(segment)?.ToString();
            if (propertyValue != "\0") //filter out null strings
                data[position] = propertyValue;
        }

        var components = string.Join(options.Separator, data);
        while (components.EndsWith(options.Separator))
            components = components.Substring(0, components.Length - 1);
        return segmentType.Name + components + options.LineEnding;
    }
}