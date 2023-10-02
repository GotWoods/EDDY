using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.x12.Mapping.Cache;
using Eddy.x12.Models;

namespace Eddy.x12.Mapping;

public class Map
{
    public static EdiX12Segment MapObject(Type t, string line, MapOptions options)
    {
        return MapObject(t, line, options.Separator, options);
    }

    public static T MapObject<T>(string line, MapOptions options) where T : new()
    {
        var segment = MapObject(typeof(T), line, options);
        return (T)Convert.ChangeType(segment, typeof(T));
    }

    private static EdiX12Segment MapObject(Type t, string line, string separator, MapOptions options) //separator is explicit here as we use the regular separator normally but can use the component element separator as well
    {
        List<string> values;
        if (line.Contains(separator))
            values = line.Split(separator.ToCharArray())
                .Select(x => x.Trim())
                .ToList();
        else //for composite types, the separator may not exist so it becomes just a singular item
            values = new List<string> { line };
        var result = (EdiX12Segment)Activator.CreateInstance(t);

        var rep = MapCache.GetMap(t);
        foreach (var item in rep.Representations)
        {
            var position = item.Position;
            if (values.Count > position)
            {
                var propertyValue = values[position];
                if (propertyValue.Trim().Length > 0)
                {
                    var underlyingType = Nullable.GetUnderlyingType(item.PropertyInfo.PropertyType) ?? item.PropertyInfo.PropertyType;
                    //composite here
                    if (underlyingType.BaseType == typeof(EdiX12Component))
                    {
                        var safeValue = MapObject(underlyingType, propertyValue.Trim(), options.ComponentElementSeparator, options);
                        item.PropertyInfo.SetValue(result, safeValue, null);
                    }
                    else
                    {
                        var safeValue = propertyValue == null ? null : Convert.ChangeType(propertyValue, underlyingType);
                        item.PropertyInfo.SetValue(result, safeValue, null);
                    }
                }
            }
        }
        return result;
    }


    


    public static string SegmentToString<T>(T segment, MapOptions options) where T : EdiX12Segment
    {
        var segmentType = segment.GetType().GetCustomAttribute<Segment>();
        var components = ItemToString(segment, options.Separator, options);
        if (string.IsNullOrEmpty(components))
            return "";
        return segmentType.Name + components + options.LineEnding;
    }

    private static string ItemToString(EdiX12Segment element, string separator, MapOptions options)
    {
        var rep = MapCache.GetMap(element.GetType());
        var data = new string[rep.Representations.Last().Position + 1];

        foreach (var item in rep.Representations)
        {
            var position = item.Position;
            var propertyValue = item.PropertyInfo.GetValue(element)?.ToString();

            var underlyingType = Nullable.GetUnderlyingType(item.PropertyInfo.PropertyType) ?? item.PropertyInfo.PropertyType;
            if (underlyingType.BaseType == typeof(EdiX12Component))
            {
                var component = (EdiX12Component)item.PropertyInfo.GetValue(element);
                if (component != null)
                    propertyValue = ItemToString(component, options.ComponentElementSeparator, options);
                else
                    propertyValue = "";
            }

            if (propertyValue != "\0") //filter out null strings
                data[position] = propertyValue;
        }

        var components = string.Join(options.Separator, data);
        while (components.EndsWith(options.Separator))
            components = components.Substring(0, components.Length - 1);
        return components;
    }

}