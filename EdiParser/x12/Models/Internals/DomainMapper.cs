using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdiParser.Attributes;
using Microsoft.Extensions.Logging;

namespace EdiParser.x12.Models.Internals;

public class DomainMapper
{

    private List<DomainTypeMap> CreatePropertyMap(Type t)
    {
        var result = Activator.CreateInstance(t);
        var props = result.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(SectionPositionAttribute))).ToList();
        var propertyMap = new List<DomainTypeMap>();

        foreach (var propertyInfo in props)
        {
            if (propertyInfo.GetCustomAttribute<SectionPositionAttribute>() == null) 
                continue;
            
            var dt = new DomainTypeMap();
            dt.MatchingSegmentType = propertyInfo.PropertyType;
            dt.TypeToGenerate = propertyInfo.PropertyType;
            dt.Property = propertyInfo;

            //if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
            if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                dt.IsListType = true;
                var genericListType = propertyInfo.PropertyType.GetGenericArguments()[0];
                dt.MatchingSegmentType = genericListType;
                dt.TypeToGenerate = dt.MatchingSegmentType;

                //Might be a list of custom objects that implement SectionPosition
                //List<BillOfLadingHandlingInfo> AT5,RTT,C3
                var childPositions = genericListType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(SectionPositionAttribute))).ToList();
                if (childPositions.Any())
                {
                    dt.IsComplexType = true;
                    foreach (var childPosition in childPositions)
                    {
                        if (childPosition.GetCustomAttribute<SectionPositionAttribute>()!.Position == 1)
                        {
                            dt.TypeToGenerate = genericListType; //taken from the list args
                            dt.MatchingSegmentType = childPosition.PropertyType; //AT5
                            break;
                        }
                    }
                }
            }
            // if (DoesTypeImplementISegmentConverter(propertyInfo.PropertyType))
            // {
            //     dt.MatchingSegmentType = "";
            // }


            propertyMap.Add(dt);
        }
        return propertyMap;
    }

    private bool DoesTypeImplementISegmentConverter(Type type)
    {
        return type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISegmentConverter<>));
    }

    private List<EdiX12Segment> _segments;
    private int currentSegmetnIndex = 0;
    private int logDepth = 0;
    private readonly ILogger<DomainMapper> _logger;
    private EdiX12Segment CurrentSegment => _segments[currentSegmetnIndex];

    public DomainMapper(List<EdiX12Segment> segments)
    {
        _segments = segments;
        _logger = Logging.Logger<DomainMapper>();
    }

    public object Map (Type t)
    {
        var result = Activator.CreateInstance(t);
        if (result == null)
            throw new NullReferenceException("Could not create type of " + t);
        var propertyMap = CreatePropertyMap(t);
        
        var firstInstanceFound = false;

        var prefix = "".PadLeft(logDepth * 2, ' ');
        while (currentSegmetnIndex < _segments.Count)
        {
          
            _logger.LogDebug($"{prefix}Processing [{currentSegmetnIndex}] {CurrentSegment.GetType()} into {result.GetType()}");

            var prop = propertyMap.FirstOrDefault(x => x.MatchingSegmentType == CurrentSegment.GetType());
            if (prop == null)
            {
                _logger.LogDebug($"{prefix}does not match any properties in this object, returning");
                //currentSegmetnIndex--; //allow the parent loop to step back and re-read this item
                return result;
            }

            if (CurrentSegment.GetType() == propertyMap.First().MatchingSegmentType && firstInstanceFound) //found the start of a new loop
            {
                _logger.LogDebug($"{prefix}Item already found. Exiting");
                //currentSegmetnIndex--; //allow the parent loop to step back and re-read this item
                return result!;
            }

            if (prop.IsComplexType && prop.IsListType)
            {
                var list = prop.Property.GetValue(result) as IList;
                logDepth++;
                list!.Add(Map(prop.TypeToGenerate));
                logDepth--;
                //currentSegmetnIndex++;
            }
            else if (prop.IsListType)
            {
                var list = prop.Property.GetValue(result) as IList;
                if (list != null)
                    list.Add(CurrentSegment);
                currentSegmetnIndex++;
            }
            else
            {
                var converted = false;
                
                if (prop.Property.PropertyType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISegmentConverter<>)))
                {
                    var convertableObject = Activator.CreateInstance(prop.Property.PropertyType);
                    // convertableObject.GetType().InvokeMember("CanConvert", BindingFlags.CreateInstance, null, )

                    var method = typeof(ISegmentConverter<>).GetMethod("CanConvert");
                    if ((bool)method.Invoke(convertableObject, null))
                    {
                        prop.Property.SetValue(result, convertableObject);
                        converted = true;
                    }
                }

                if (!converted)
                {
                    prop.Property.SetValue(result, CurrentSegment);
                    firstInstanceFound = true;
                }

                currentSegmetnIndex++;
            }
        }

        return result;
    }

    public T Map<T>()
    {
        return (T)Map(typeof(T));

    }

    
    
}