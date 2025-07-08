using Eddy.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Eddy.Core.Extension
{
    /// <summary>
    /// Generic extension methods for analyzing EDI message structure
    /// Can be used with any EDI message class that uses Eddy.Core.Attributes
    /// </summary>
    public static class EdiStructureExtensions
    {
        /// <summary>
        /// Gets a formatted string representation of the EDI message structure
        /// Shows SectionPosition -> Segment -> Position hierarchy
        /// </summary>
        /// <typeparam name="T">Any EDI message type</typeparam>
        /// <param name="message">The EDI message instance</param>
        /// <returns>Formatted structure map</returns>
        public static string GetStructureMap<T>(this T message) where T : class
        {
            var structureBuilder = new StringBuilder();
            var messageType = typeof(T);

            // Get all properties with SectionPosition attribute
            var properties = messageType.GetProperties()
                .Where(p => p.GetCustomAttribute<SectionPositionAttribute>() != null)
                .OrderBy(p => p.GetCustomAttribute<SectionPositionAttribute>().Position)
                .ToList();

            foreach (var property in properties)
            {
                var sectionPosition = property.GetCustomAttribute<SectionPositionAttribute>().Position;
                var propertyName = property.Name;

                // Handle List<T> properties
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var listItemType = property.PropertyType.GetGenericArguments()[0];
                    structureBuilder.AppendLine($"{sectionPosition:D2} - {propertyName}");

                    // Get segment information from the list item type
                    ProcessSegmentType(listItemType, structureBuilder, 1);
                }
                else
                {
                    // Handle single segment properties
                    structureBuilder.AppendLine($"{sectionPosition:D2} - {propertyName}");
                    ProcessSegmentType(property.PropertyType, structureBuilder, 1);
                }
            }

            return structureBuilder.ToString();
        }

        /// <summary>
        /// Gets structured data representation of the EDI message
        /// Returns objects for programmatic access to structure information
        /// </summary>
        /// <typeparam name="T">Any EDI message type</typeparam>
        /// <param name="message">The EDI message instance</param>
        /// <returns>List of structure items</returns>
        public static List<EdiStructureItem> GetStructureItems<T>(this T message) where T : class
        {
            var structureItems = new List<EdiStructureItem>();
            var messageType = typeof(T);

            // Get all properties with SectionPosition attribute
            var properties = messageType.GetProperties()
                .Where(p => p.GetCustomAttribute<SectionPositionAttribute>() != null)
                .OrderBy(p => p.GetCustomAttribute<SectionPositionAttribute>().Position)
                .ToList();

            foreach (var property in properties)
            {
                var sectionPosition = property.GetCustomAttribute<SectionPositionAttribute>().Position;
                var propertyName = property.Name;

                // Handle List<T> properties
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var listItemType = property.PropertyType.GetGenericArguments()[0];
                    var structureItem = new EdiStructureItem
                    {
                        SectionPosition = sectionPosition,
                        PropertyName = propertyName,
                        Segments = GetSegmentItems(listItemType)
                    };
                    structureItems.Add(structureItem);
                }
                else
                {
                    // Handle single segment properties
                    var structureItem = new EdiStructureItem
                    {
                        SectionPosition = sectionPosition,
                        PropertyName = propertyName,
                        Segments = GetSegmentItems(property.PropertyType)
                    };
                    structureItems.Add(structureItem);
                }
            }

            return structureItems;
        }

        /// <summary>
        /// Analyzes a type and extracts EDI segment information
        /// </summary>
        private static void ProcessSegmentType(Type segmentType, StringBuilder builder, int indentLevel)
        {
            var indent = new string(' ', indentLevel * 2);

            // Get SegmentAttribute from your Eddy.Core.Attributes
            var segmentAttribute = segmentType.GetCustomAttribute<Segment>();
            if (segmentAttribute != null)
            {
                builder.AppendLine($"{indent}{segmentAttribute.Name} - {segmentType.Name}");

                // Get all properties with PositionAttribute
                var positionProperties = segmentType.GetProperties()
                    .Where(p => p.GetCustomAttribute<PositionAttribute>() != null)
                    .OrderBy(p => p.GetCustomAttribute<PositionAttribute>().Position)
                    .ToList();

                foreach (var prop in positionProperties)
                {
                    var position = prop.GetCustomAttribute<PositionAttribute>().Position;
                    var propertyName = prop.Name;
                    builder.AppendLine($"{indent}  {position}  {propertyName}");
                }
            }
            else
            {
                // Fallback: look for PositionAttribute to identify it as a segment
                var positionProperties = segmentType.GetProperties()
                    .Where(p => p.GetCustomAttribute<PositionAttribute>() != null)
                    .OrderBy(p => p.GetCustomAttribute<PositionAttribute>().Position)
                    .ToList();

                if (positionProperties.Any())
                {
                    // This appears to be a segment if it has Position attributes
                    // Extract segment code from type name (e.g., ST_TransactionSetHeader -> ST)
                    var segmentCode = ExtractSegmentCode(segmentType.Name);
                    builder.AppendLine($"{indent}{segmentCode} - {segmentType.Name}");

                    foreach (var prop in positionProperties)
                    {
                        var position = prop.GetCustomAttribute<PositionAttribute>().Position;
                        var propertyName = prop.Name;
                        builder.AppendLine($"{indent}  {position}  {propertyName}");
                    }
                }
                else
                {
                    // Handle complex types (like loops) that might contain segments
                    var nestedProperties = segmentType.GetProperties()
                        .Where(p => p.GetCustomAttribute<SectionPositionAttribute>() != null ||
                                   HasPositionAttributes(p.PropertyType))
                        .OrderBy(p => p.GetCustomAttribute<SectionPositionAttribute>()?.Position ?? 0)
                        .ToList();

                    if (nestedProperties.Any())
                    {
                        builder.AppendLine($"{indent}{segmentType.Name}");
                        foreach (var nestedProp in nestedProperties)
                        {
                            if (nestedProp.PropertyType.IsGenericType &&
                                nestedProp.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                            {
                                var listItemType = nestedProp.PropertyType.GetGenericArguments()[0];
                                ProcessSegmentType(listItemType, builder, indentLevel + 1);
                            }
                            else
                            {
                                ProcessSegmentType(nestedProp.PropertyType, builder, indentLevel + 1);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets segment items from a type
        /// </summary>
        private static List<EdiSegmentItem> GetSegmentItems(Type segmentType)
        {
            var segmentItems = new List<EdiSegmentItem>();

            // Get SegmentAttribute from your Eddy.Core.Attributes
            var segmentAttribute = segmentType.GetCustomAttribute<Segment>();
            if (segmentAttribute != null)
            {
                var segmentItem = new EdiSegmentItem
                {
                    SegmentName = segmentAttribute.Name,
                    SegmentTypeName = segmentType.Name,
                    Positions = GetPositionItems(segmentType)
                };
                segmentItems.Add(segmentItem);
            }
            else
            {
                // Check if this type has PositionAttribute (indicating it's a segment)
                var positionProperties = segmentType.GetProperties()
                    .Where(p => p.GetCustomAttribute<PositionAttribute>() != null)
                    .OrderBy(p => p.GetCustomAttribute<PositionAttribute>().Position)
                    .ToList();

                if (positionProperties.Any())
                {
                    // This appears to be a segment
                    var segmentCode = ExtractSegmentCode(segmentType.Name);
                    var segmentItem = new EdiSegmentItem
                    {
                        SegmentName = segmentCode,
                        SegmentTypeName = segmentType.Name,
                        Positions = GetPositionItems(segmentType)
                    };
                    segmentItems.Add(segmentItem);
                }
                else
                {
                    // Handle complex types (like loops) that might contain segments
                    var nestedProperties = segmentType.GetProperties()
                        .Where(p => p.GetCustomAttribute<SectionPositionAttribute>() != null ||
                                   HasPositionAttributes(p.PropertyType))
                        .OrderBy(p => p.GetCustomAttribute<SectionPositionAttribute>()?.Position ?? 0)
                        .ToList();

                    foreach (var nestedProp in nestedProperties)
                    {
                        if (nestedProp.PropertyType.IsGenericType &&
                            nestedProp.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            var listItemType = nestedProp.PropertyType.GetGenericArguments()[0];
                            segmentItems.AddRange(GetSegmentItems(listItemType));
                        }
                        else
                        {
                            segmentItems.AddRange(GetSegmentItems(nestedProp.PropertyType));
                        }
                    }
                }
            }

            return segmentItems;
        }

        /// <summary>
        /// Gets position items from a segment type
        /// </summary>
        private static List<EdiPositionItem> GetPositionItems(Type segmentType)
        {
            var positionItems = new List<EdiPositionItem>();

            // Get all properties with PositionAttribute
            var positionProperties = segmentType.GetProperties()
                .Where(p => p.GetCustomAttribute<PositionAttribute>() != null)
                .OrderBy(p => p.GetCustomAttribute<PositionAttribute>().Position)
                .ToList();

            foreach (var prop in positionProperties)
            {
                var position = prop.GetCustomAttribute<PositionAttribute>().Position;
                var propertyName = prop.Name;

                var positionItem = new EdiPositionItem
                {
                    Position = position,
                    PropertyName = propertyName
                };
                positionItems.Add(positionItem);
            }

            return positionItems;
        }

        /// <summary>
        /// Extracts segment code from type name
        /// </summary>
        private static string ExtractSegmentCode(string typeName)
        {
            // Extract segment code from type name (e.g., ST_TransactionSetHeader -> ST)
            if (typeName.Contains("_"))
            {
                return typeName.Split('_')[0];
            }
            return typeName;
        }

        /// <summary>
        /// Checks if a type has position attributes
        /// </summary>
        private static bool HasPositionAttributes(Type type)
        {
            return type.GetProperties()
                .Any(p => p.GetCustomAttribute<PositionAttribute>() != null);
        }
    }

    #region Data Transfer Objects

    /// <summary>
    /// Represents a section in an EDI message structure
    /// </summary>
    public class EdiStructureItem
    {
        public int SectionPosition { get; set; }
        public string PropertyName { get; set; }
        public List<EdiSegmentItem> Segments { get; set; } = new List<EdiSegmentItem>();
    }

    /// <summary>
    /// Represents an EDI segment
    /// </summary>
    public class EdiSegmentItem
    {
        public string SegmentName { get; set; }
        public string SegmentTypeName { get; set; }
        public List<EdiPositionItem> Positions { get; set; } = new List<EdiPositionItem>();
    }

    /// <summary>
    /// Represents a position/field within an EDI segment
    /// </summary>
    public class EdiPositionItem
    {
        public int Position { get; set; }
        public string PropertyName { get; set; }
    }

    #endregion
}
