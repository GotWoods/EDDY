using Eddy.Core.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Eddy.x12.Mapping.Cache
{
    internal static class DomainMapCache
    {
        private static readonly ConcurrentDictionary<Type, List<DomainTypeMap>> _segmentMapCache = new();

        // Concurrent callers used to race here: both would miss on TryGetValue and both
        // would Add, throwing "An item with the same key has already been added".
        // GetOrAdd can still run CreatePropertyMap more than once for a type under
        // contention, but it only ever publishes one map, and CreatePropertyMap is pure
        // reflection over t, so the duplicated work is harmless.
        public static List<DomainTypeMap> GetMap(Type t) => _segmentMapCache.GetOrAdd(t, CreatePropertyMap);


        private static List<DomainTypeMap> CreatePropertyMap(Type t)
        {
            var props = t.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(SectionPositionAttribute)));
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
                            if (childPosition.GetCustomAttribute<SectionPositionAttribute>()!.Position == 1)
                            {
                                dt.TypeToGenerate = genericListType; //taken from the list args
                                dt.MatchingSegmentType = childPosition.PropertyType; //AT5
                                break;
                            }
                    }
                }
                else
                {
                    var childPositions = propertyInfo.PropertyType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(SectionPositionAttribute))).ToList();
                    if (childPositions.Any())
                    {
                        dt.IsComplexType = true;
                        foreach (var childPosition in childPositions)
                            if (childPosition.GetCustomAttribute<SectionPositionAttribute>()!.Position == 1)
                            {
                                //dt.TypeToGenerate = genericListType; //taken from the list args
                                dt.MatchingSegmentType = childPosition.PropertyType; //AT5
                                break;
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
    }



}
