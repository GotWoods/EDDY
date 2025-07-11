using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;

namespace Eddy.Core.DocumentStructure
{
    public class Structure
    {
        public static List<Section> Of<T>()
        {
            return Of(typeof(T));
        }

        public static List<Section> Of(Type messageType)
        {
            var structureItems = new List<Section>();
            

            // Get all properties with SectionPosition attribute
            var properties = messageType.GetProperties()
                .Where(p => p.GetCustomAttribute<SectionPositionAttribute>() != null)
                .OrderBy(p => p.GetCustomAttribute<SectionPositionAttribute>().Position)
                .ToList();

            foreach (var property in properties)
            {
                if (!property.PropertyType.IsGenericType || property.PropertyType.GetGenericTypeDefinition() != typeof(List<>))
                {
                    var propertyName = property.PropertyType.Name.Split('_');
                    // Handle single segment properties
                    var structureItem = new Section
                    {
                        Name = propertyName[1],
                        Code = propertyName[0],
                        SectionType = SectionType.Segment,
                        Segments = GetSegments(property.PropertyType)
                    };
                    structureItems.Add(structureItem);
                }
                else // Handle List<T> properties
                {
                    var listItemType = property.PropertyType.GetGenericArguments()[0];
                    if (listItemType.Namespace.IndexOf("Eddy.x12.DomainModels") == -1)
                    {
                        var propertyName = listItemType.Name.Split('_');
                        var structureItem = new Section
                        {
                            Name = propertyName[1],
                            Code = propertyName[0],
                            SectionType = SectionType.RepeatingSegment
                        };
                        structureItems.Add(structureItem);
                    }
                    else
                    {
                        var propertyName = listItemType.Name;
                        var structureItem = new Section
                        {
                            Name = propertyName,
                            Code = propertyName,
                            SectionType = SectionType.RepeatingComplexType,
                            Sections = Of(listItemType)
                        };
                        structureItems.Add(structureItem);
                    }
                }
            }

            return structureItems;
        }

        public static List<Segment> GetSegments(Type type)
        {
            // Get all properties with SectionPosition attribute
            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute<PositionAttribute>() != null)
                .OrderBy(p => p.GetCustomAttribute<PositionAttribute>().Position)
                .ToList();

            var segments = new List<Segment>();

            foreach (var property in properties)
            {
                var position = property.GetCustomAttribute<PositionAttribute>().Position;

                var segment = new Segment();
                segment.Position = position;
                segment.Name = property.Name;
                segments.Add(segment);
            }

            return segments;
        }
        }
}
