using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core;
using Eddy.Core.Attributes;
using Eddy.x12.Mapping.Cache;
using Eddy.x12.Models;

namespace Eddy.x12.Mapping;

public class DomainMapper
{
    //private readonly ILogger<DomainMapper> _logger;

    private readonly List<EdiX12Segment> _segments;
    private int _currentSegmetnIndex;
    private int _logDepth;

    public DomainMapper(List<EdiX12Segment> segments)
    {
        _segments = segments;
      //  _logger = Logging.Logger<DomainMapper>();
    }

    public DomainMapper()
    {
//        _logger = Logging.Logger<DomainMapper>();
    }

    private EdiX12Segment CurrentSegment => _segments[_currentSegmetnIndex];

   

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

    /// <summary>
    /// Same walk as <see cref="Map(Type)"/>, but also reports which segments were consumed, which were
    /// left over, and - for the first segment that stopped the walk - why. The stop is always "this
    /// segment did not match any property still expected on the object being built at that point"; every
    /// segment after it is reported separately as simply not mapped, since the walk never got far enough
    /// to consider them at all.
    /// </summary>
    public DomainMapResult<object> MapWithDiagnostics(Type t)
    {
        var value = Map(t);
        return BuildResult(value, t.Name);
    }

    public DomainMapResult<T> MapWithDiagnostics<T>()
    {
        var untyped = MapWithDiagnostics(typeof(T));
        return new DomainMapResult<T>
        {
            Value = (T)untyped.Value,
            UnmappedSegments = untyped.UnmappedSegments,
            Diagnostics = untyped.Diagnostics,
            ConsumedSegments = untyped.ConsumedSegments
        };
    }

    private DomainMapResult<object> BuildResult(object value, string typeName)
    {
        var result = new DomainMapResult<object> { Value = value };

        for (var i = 0; i < _currentSegmetnIndex && i < _segments.Count; i++)
            result.ConsumedSegments.Add(_segments[i]);

        for (var i = _currentSegmetnIndex; i < _segments.Count; i++)
        {
            var segment = _segments[i];
            result.UnmappedSegments.Add(segment);

            var message = i == _currentSegmetnIndex
                ? $"Segment {DescribeSegment(segment)} is not expected here; mapping of {typeName} stopped"
                : $"Segment {DescribeSegment(segment)} was not mapped";

            result.Diagnostics.Add(new DomainMapDiagnostic
            {
                Segment = segment,
                Source = segment.Source,
                Message = message
            });
        }

        return result;
    }

    private static string DescribeSegment(EdiX12Segment segment)
    {
        var id = SegmentId(segment);
        return segment.Source != null ? $"{id} at line {segment.Source.LineNumber}" : id;
    }

    private static string SegmentId(EdiX12Segment segment)
    {
        if (segment is Unknown_Segment unknown)
            return unknown.SegmentId;

        var attr = segment.GetType().GetCustomAttribute<Segment>();
        return attr?.Name ?? segment.GetType().Name;
    }


    public List<EdiX12Segment> MapToSegments<T>(T input)
    {
        var result = new List<EdiX12Segment>();
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
                    var value = item as EdiX12Segment;
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
                var value = map.Property.GetValue(input) as EdiX12Segment;
                if (value != null)
                    result.Add(value);
            }

        //examine object and build ordered array of properties with their index
        //for each element in array, convert to string

        return result;
    }
}