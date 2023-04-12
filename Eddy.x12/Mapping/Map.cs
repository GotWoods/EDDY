using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.Mapping;

public class Map
{
    public static EdiX12Segment MapObject(Type t, string line, MapOptions options)
    {
        return MapObject(t, line, options.Separator, options);
    }
    
    private static EdiX12Segment MapObject(Type t, string line, string separator, MapOptions options) //seperator is explict here as we use the regular separator normally but can use the component element separator as well
    {
        List<string> values;
        if (line.Contains(separator))
        {

            values = line.Split(separator.ToCharArray())
                .Select(x => x.Trim())
                .ToList();
        }
        else //for composite types, the separator may not exist so it becomes just a singular item
        {
            values = new List<string>() { line };
        }
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
                    //composite here
                    if (underlyingType.BaseType == typeof(EdiX12Component))
                    {
                        var safeValue = MapObject(underlyingType, propertyValue.Trim(), options.ComponentElementSeparator, options);
                        propertyInfo.SetValue(result, safeValue, null);
                    }
                    else
                    {
                        var safeValue = propertyValue == null ? null : Convert.ChangeType(propertyValue, underlyingType);
                        propertyInfo.SetValue(result, safeValue, null);
                    }
                    
                }
            }
        }

        //if (options.PerformValidations) result.ValidationResult = result.Validate();

        return result;
    }

    public static T MapObject<T>(string line, MapOptions options) where T : new()
    {
        var segment = MapObject(typeof(T), line, options);
        return (T)Convert.ChangeType(segment, typeof(T));
        ;
    }

    private static string ItemToString(EdiX12Segment element, string separator, MapOptions options) 
    {
        var props = element.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(PositionAttribute)));
        var data = new string[props.Max(x => x.GetCustomAttribute<PositionAttribute>().Position) + 1];

        //there is no gaurantee the properties will be in order in the class so we dump the values into an array 
        foreach (var propertyInfo in props)
        {
            var position = propertyInfo.GetCustomAttribute<PositionAttribute>().Position;
            var propertyValue = propertyInfo.GetValue(element)?.ToString();

            var underlyingType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            if (underlyingType.BaseType == typeof(EdiX12Component))
            {
                var component = (EdiX12Component)propertyInfo.GetValue(element);
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

    public static string SegmentToString<T>(T segment, MapOptions options) where T : EdiX12Segment
    {
        var segmentType = segment.GetType().GetCustomAttribute<Segment>();
        var components = ItemToString(segment, options.Separator, options);
        if (string.IsNullOrEmpty(components))
            return "";
        return segmentType.Name + components + options.LineEnding;
    }
}