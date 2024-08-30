using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;

namespace Eddy.Edifact.Mapping
{
    internal static class DomainMapCache
    {
        private static readonly Dictionary<Type, List<DomainTypeMap>> _segmentMapCache = new();
        public static List<DomainTypeMap> GetMap(Type t)
        {
            if (_segmentMapCache.TryGetValue(t, out var map))
                return map;

            var rep = CreatePropertyMap(t);
            _segmentMapCache.Add(t, rep);
            return rep;
        }


        internal static List<DomainTypeMap> CreatePropertyMap(Type t)
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
