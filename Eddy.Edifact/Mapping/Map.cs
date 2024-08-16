using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.Edifact.Mapping.Cache;
using Eddy.Edifact.Models.Elements;

namespace Eddy.Edifact.Mapping;

public class Map
{
    public static object MapObject(Type t, string line, MapOptions options)
    {
        return MapObject(t, line, options.Separator, 0, options);
    }

    public static EdifactSegment MapObject(Type t, string line, string separator, int positionOffset, MapOptions options) //separator is explicit here as we use the regular separator normally but can use the component element separator as well
    {
        List<string> values;
        if (line.Contains(separator))
            values = line.Split(separator.ToCharArray())
                .Select(x => x.Trim())
                .ToList();
        else //for composite types, the separator may not exist so it becomes just a singular item
            values = new List<string> { line };
        var result = (EdifactSegment)Activator.CreateInstance(t);

        var rep = MapCache.GetMap(t);
        foreach (var item in rep.Representations)
        {
            var position = item.Position+positionOffset;
            if (values.Count > position)
            {
                var propertyValue = values[position];
                if (propertyValue.Trim().Length > 0)
                {
                    var underlyingType = Nullable.GetUnderlyingType(item.PropertyInfo.PropertyType) ?? item.PropertyInfo.PropertyType;
                    //composite here
                    if (underlyingType.BaseType == typeof(EdifactComponent))
                    {
                        var safeValue = MapObject(underlyingType, propertyValue.Trim(), options.ComponentElementSeparator, -1, options);
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
    public static T MapObject<T>(string line, MapOptions options) where T : new()
    {
        var segment = MapObject(typeof(T), line, options);
        return (T)Convert.ChangeType(segment, typeof(T)); ;
    }

    public static T MapComposite<T>(string line, MapOptions options) where T : new()
    {
        var segment = MapObject(typeof(T), line, options.ComponentElementSeparator, -1, options);
        return (T)Convert.ChangeType(segment, typeof(T)); ;
    }
}