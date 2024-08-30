using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Eddy.Edifact.Mapping;

public class DomainMapper
{
    //private readonly ILogger<DomainMapper> _logger;

    private readonly List<EdifactSegment> _segments;
    private int _currentSegmetnIndex;
    private int _logDepth;

    public DomainMapper(List<EdifactSegment> segments)
    {
        _segments = segments;
      //  _logger = Logging.Logger<DomainMapper>();
    }

    public DomainMapper()
    {
//        _logger = Logging.Logger<DomainMapper>();
    }

    private EdifactSegment CurrentSegment => _segments[_currentSegmetnIndex];

   

    public object Map(Type t)
    {
        var result = Activator.CreateInstance(t);
        if (result == null)
            throw new NullReferenceException("Could not create type of " + t);
        var propertyMap = DomainMapCache.GetMap(t);

        var firstInstanceFound = false;

        var prefix = "".PadLeft(_logDepth * 2, ' ');
        while (_currentSegmetnIndex < _segments.Count)
        {
           // _logger.LogDebug($"{prefix}Processing [{_currentSegmetnIndex}] {CurrentSegment.GetType()} into {result.GetType()}");

            var prop = propertyMap.FirstOrDefault(x => x.MatchingSegmentType == CurrentSegment.GetType());
            if (prop == null)
            {
              //  _logger.LogDebug($"{prefix}does not match any properties in this object, returning");
                return result;
            }

            if (CurrentSegment.GetType() == propertyMap.First().MatchingSegmentType && firstInstanceFound) //found the start of a new loop
            {
            //    _logger.LogDebug($"{prefix}Item already found. Exiting");
                return result!;
            }

            if (prop.IsComplexType && prop.IsListType)
            {
                var list = prop.Property.GetValue(result) as IList;
                _logDepth++;
                list!.Add(Map(prop.TypeToGenerate));
                _logDepth--;
            }
            else if (prop.IsListType)
            {
                var list = prop.Property.GetValue(result) as IList;
                if (list != null)
                    list.Add(CurrentSegment);
                _currentSegmetnIndex++;
            }
            else if (prop.IsComplexType)
            {
                var complexType = Map(prop.TypeToGenerate);
                prop.Property.SetValue(result, complexType);
                firstInstanceFound = true;
            }
            else
            {
                //var converted = false;

                // if (prop.Property.PropertyType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISegmentConverter<>)))
                // {
                //     var convertableObject = Activator.CreateInstance(prop.Property.PropertyType);
                //     // convertableObject.GetType().InvokeMember("CanConvert", BindingFlags.CreateInstance, null, )
                //
                //     var method = typeof(ISegmentConverter<>).GetMethod("CanConvert");
                //     if ((bool)method.Invoke(convertableObject, null))
                //     {
                //         prop.Property.SetValue(result, convertableObject);
                //         converted = true;
                //     }
                // }

                // if (!converted)
                // {
                prop.Property.SetValue(result, CurrentSegment);
                firstInstanceFound = true;
                //}

                _currentSegmetnIndex++;
            }
        }

        return result;
    }

    public T Map<T>()
    {
        return (T)Map(typeof(T));
    }


    public List<EdifactSegment> MapToSegments<T>(T input)
    {
        var result = new List<EdifactSegment>();
        var propertyMap = DomainMapCache.GetMap(input.GetType()); // CreatePropertyMap(input.GetType());

        foreach (var map in propertyMap)
            if (map.IsComplexType && map.IsListType)
            {
                var list = map.Property.GetValue(input) as IList; //e.g. list of entity
                if (list == null)
                    throw new NullReferenceException(map.Property.Name + " was expected to be an IList type that is initialized but it was null");
                //need to get all properties of this
                foreach (var item in list)
                {
                    result.AddRange(MapToSegments(item));
                }
            }
            else if (map.IsListType)
            {
                var list = map.Property.GetValue(input) as IList;
                if (list == null)
                    throw new NullReferenceException(map.Property.Name + " was expected to be an instantiated list but was null");
                foreach (var item in list)
                {
                    var value = item as EdifactSegment;
                    if (value != null)
                        result.Add(value);
                }
            }
            else if (map.IsComplexType)
            {
                var complexType = map.Property.GetValue(input); //e.g. single entity
                if (complexType == null)
                    continue;
                result.AddRange(MapToSegments(complexType));
            }
            else
            {
                var value = map.Property.GetValue(input) as EdifactSegment;
                if (value != null)
                    result.Add(value);
            }

        //examine object and build ordered array of properties with their index
        //for each element in array, convert to string

        return result;
    }
}