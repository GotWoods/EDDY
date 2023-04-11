using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.Core.EdiFact.Models.Elements;

namespace Eddy.Core.EdiFact.Mapping;

public class Map
{
    public static object MapObject(Type t, string line, MapOptions options)
    {
        var values = line.Split(options.Separator.ToCharArray())
            .Select(x => x.Trim())
            .ToList();

        var result = (object)Activator.CreateInstance(t);
        LinkValuesToObject(result, values, 0);
        return result;
    }

    private static void LinkValuesToObject(object result, List<string> values, int offset)
    {
        var props = result.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(PositionAttribute)));
        foreach (var propertyInfo in props)
        {
            var position = propertyInfo.GetCustomAttribute<PositionAttribute>().Position;
            if (values.Count() > position+offset)
            {
                var propertyValue = values[position + offset];
                if (propertyValue.Trim().Length > 0)
                {
                    if (propertyInfo.PropertyType.BaseType == typeof(IElement))
                    {
                        var element = MapElement(propertyInfo.PropertyType, values[position]);
                        propertyInfo.SetValue(result, Convert.ChangeType(element, propertyInfo.PropertyType), null);
                    }
                    else
                    {
                        propertyInfo.SetValue(result, Convert.ChangeType(propertyValue, propertyInfo.PropertyType), null);
                    }
                }
            }
        }
    }

    public static IElement MapElement(Type t, string part)
    {
        var values = part.Split(':')
            .Select(x => x.Trim())
            .ToList(); ;
        var result = (IElement)Activator.CreateInstance(t);
        LinkValuesToObject(result, values, -1); 
        return result;
    }

    public static T MapObject<T>(string line, MapOptions options) where T : new()
    {
        var segment = MapObject(typeof(T), line, options);
        return (T)Convert.ChangeType(segment, typeof(T)); ;
    }
}