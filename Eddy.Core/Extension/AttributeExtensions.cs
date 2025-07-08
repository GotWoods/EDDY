using Eddy.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Eddy.Core.Extension
{
    public static class AttributeExtensions
    {
        public static (int? SectionPosition, string? SegmentCode, int? Position)[] GetPositionalAttributes(this Type type)
        {
            var properties = type.GetProperties();
            var results = new List<(int? SectionPosition, string? SegmentCode, int? Position)>();

            // Get segment attribute if present at class level
            var segmentAttr = type.GetCustomAttributes(typeof(Segment), false).FirstOrDefault() as Segment;
            string? segmentCode = segmentAttr?.Name;

            foreach (var prop in properties)
            {
                var sectionPosAttr = prop.GetCustomAttribute<SectionPositionAttribute>();
                var posAttr = prop.GetCustomAttribute<PositionAttribute>();

                results.Add((
                    sectionPosAttr?.Position,
                    segmentCode,
                    posAttr?.Position
                ));
            }

            return results.ToArray();
        }

        public static (int? SectionPosition, string? SegmentCode, int? Position) GetPositionalAttributes(this PropertyInfo property)
        {
            var declaringType = property.DeclaringType;
            var segmentAttr = declaringType?.GetCustomAttributes(typeof(Segment), false).FirstOrDefault() as Segment;
            var sectionPosAttr = property.GetCustomAttribute<SectionPositionAttribute>();
            var posAttr = property.GetCustomAttribute<PositionAttribute>();

            return (
                sectionPosAttr?.Position,
                segmentAttr?.Name,
                posAttr?.Position
            );
        }
    }
}
