using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;

namespace Eddy.Core.Extension
{
    /// <summary>
    /// Clean, working EDI data extractor that uses position numbers and segment codes
    /// </summary>
    public static class EdiValueExtractor
    {
        /// <summary>
        /// Extract value by position number from EDI object
        /// </summary>
        /// <typeparam name="T">EDI message type</typeparam>
        /// <param name="ediObject">The EDI object with data</param>
        /// <param name="sectionPropertyName">Property name of the section (e.g., "BeginningSegmentForTransportationCarrierShipmentStatusMessage")</param>
        /// <param name="segmentCode">Segment code (e.g., "B10", "L11")</param>
        /// <param name="position">Position number (1, 2, 3, etc.)</param>
        /// <param name="instanceIndex">Instance index for repeating elements (optional)</param>
        /// <returns>The value at the specified position or null if not found</returns>
        public static object GetValueByPosition<T>(this T ediObject, string sectionPropertyName, string segmentCode, int position, int? instanceIndex = null) where T : class
        {
            if (ediObject == null) return null;

            // Find the section property
            var sectionProperty = FindSectionProperty(typeof(T), sectionPropertyName);
            if (sectionProperty == null) return null;

            var sectionValue = sectionProperty.GetValue(ediObject);
            if (sectionValue == null) return null;

            // Handle collections vs single objects
            if (IsCollection(sectionProperty.PropertyType))
            {
                return GetValueFromCollection(sectionValue, segmentCode, position, instanceIndex);
            }
            else
            {
                return GetValueFromObject(sectionValue, segmentCode, position);
            }
        }

        /// <summary>
        /// Extract value by property name from EDI object
        /// </summary>
        public static object GetValueByName<T>(this T ediObject, string sectionPropertyName, string segmentCode, string positionName, int? instanceIndex = null) where T : class
        {
            if (ediObject == null) return null;

            var sectionProperty = FindSectionProperty(typeof(T), sectionPropertyName);
            if (sectionProperty == null) return null;

            var sectionValue = sectionProperty.GetValue(ediObject);
            if (sectionValue == null) return null;

            if (IsCollection(sectionProperty.PropertyType))
            {
                return GetValueFromCollectionByName(sectionValue, segmentCode, positionName, instanceIndex);
            }
            else
            {
                return GetValueFromObjectByName(sectionValue, segmentCode, positionName);
            }
        }

        /// <summary>
        /// Get all position values from a segment
        /// </summary>
        public static Dictionary<int, object> GetAllPositions<T>(this T ediObject, string sectionPropertyName, string segmentCode, int? instanceIndex = null) where T : class
        {
            var result = new Dictionary<int, object>();
            if (ediObject == null) return result;

            var sectionProperty = FindSectionProperty(typeof(T), sectionPropertyName);
            if (sectionProperty == null) return result;

            var sectionValue = sectionProperty.GetValue(ediObject);
            if (sectionValue == null) return result;

            if (IsCollection(sectionProperty.PropertyType))
            {
                var enumerable = (System.Collections.IEnumerable)sectionValue;
                var items = enumerable.Cast<object>().ToList();

                var targetIndex = instanceIndex ?? 0;
                if (targetIndex >= 0 && targetIndex < items.Count)
                {
                    return GetAllPositionsFromSegment(items[targetIndex], segmentCode);
                }
            }
            else
            {
                return GetAllPositionsFromSegment(sectionValue, segmentCode);
            }

            return result;
        }

        #region Private Helper Methods

        private static PropertyInfo FindSectionProperty(Type type, string propertyName)
        {
            var properties = type.GetProperties();

            // Try exact match
            var exactMatch = properties.FirstOrDefault(p =>
                p.Name.ToString().Equals(propertyName, StringComparison.OrdinalIgnoreCase));
            if (exactMatch != null) return exactMatch;

            // Try contains match
            var result = properties.FirstOrDefault(p =>
                p.Name.ToUpper().Contains(propertyName.ToUpper())); //, StringComparison.OrdinalIgnoreCase));

             return result;
        }

        private static bool IsCollection(Type type)
        {
            return typeof(System.Collections.IEnumerable).IsAssignableFrom(type) && type != typeof(string);
        }

        private static object GetValueFromCollection(object collectionValue, string segmentCode, int position, int? instanceIndex)
        {
            var enumerable = (System.Collections.IEnumerable)collectionValue;
            var items = enumerable.Cast<object>().ToList();

            if (items.Count == 0) return null;

            var targetIndex = instanceIndex ?? 0;
            if (targetIndex >= items.Count) return null;

            return GetValueFromObject(items[targetIndex], segmentCode, position);
        }

        private static object GetValueFromCollectionByName(object collectionValue, string segmentCode, string positionName, int? instanceIndex)
        {
            var enumerable = (System.Collections.IEnumerable)collectionValue;
            var items = enumerable.Cast<object>().ToList();

            if (items.Count == 0) return null;

            var targetIndex = instanceIndex ?? 0;
            if (targetIndex >= items.Count) return null;

            return GetValueFromObjectByName(items[targetIndex], segmentCode, positionName);
        }

        private static object GetValueFromObject(object obj, string segmentCode, int position)
        {
            if (obj == null) return null;

            // Check if this object itself is the segment
            if (obj.GetType().Name.StartsWith(segmentCode + "_"))
            {
                return GetPositionValueFromSegment(obj, position);
            }

            // Search through properties
            var properties = obj.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(obj);
                if (propValue == null) continue;

                // Check if property type is the segment
                if (prop.PropertyType.Name.StartsWith(segmentCode + "_"))
                {
                    return GetPositionValueFromSegment(propValue, position);
                }

                // Check collections
                if (IsCollection(prop.PropertyType))
                {
                    var enumerable = (System.Collections.IEnumerable)propValue;
                    foreach (var item in enumerable)
                    {
                        if (item?.GetType().Name.StartsWith(segmentCode + "_") == true)
                        {
                            var result = GetPositionValueFromSegment(item, position);
                            if (result != null) return result;
                        }
                        else if (item != null)
                        {
                            var result = GetValueFromObject(item, segmentCode, position);
                            if (result != null) return result;
                        }
                    }
                }

                // Check nested objects
                if (!IsCollection(prop.PropertyType) && prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                {
                    var result = GetValueFromObject(propValue, segmentCode, position);
                    if (result != null) return result;
                }
            }

            return null;
        }

        private static object GetValueFromObjectByName(object obj, string segmentCode, string positionName)
        {
            if (obj == null) return null;

            // Check if this object itself is the segment
            if (obj.GetType().Name.StartsWith(segmentCode + "_"))
            {
                return GetPropertyValue(obj, positionName);
            }

            // Search through properties
            var properties = obj.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(obj);
                if (propValue == null) continue;

                // Check if property type is the segment
                if (prop.PropertyType.Name.StartsWith(segmentCode + "_"))
                {
                    return GetPropertyValue(propValue, positionName);
                }

                // Check collections
                if (IsCollection(prop.PropertyType))
                {
                    var enumerable = (System.Collections.IEnumerable)propValue;
                    foreach (var item in enumerable)
                    {
                        if (item?.GetType().Name.StartsWith(segmentCode + "_") == true)
                        {
                            var result = GetPropertyValue(item, positionName);
                            if (result != null) return result;
                        }
                        else if (item != null)
                        {
                            var result = GetValueFromObjectByName(item, segmentCode, positionName);
                            if (result != null) return result;
                        }
                    }
                }

                // Check nested objects
                if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                {
                    var result = GetValueFromObjectByName(propValue, segmentCode, positionName);
                    if (result != null) return result;
                }
            }

            return null;
        }

        private static object GetPositionValueFromSegment(object segmentObject, int position)
        {
            if (segmentObject == null) return null;

            var properties = segmentObject.GetType().GetProperties();
            foreach (var prop in properties)
            {
                try
                {
                    var positionAttrs = prop.GetCustomAttributes(typeof(PositionAttribute), false);
                    if (positionAttrs.Length > 0 && positionAttrs[0] is PositionAttribute positionAttr)
                    {
                        if (positionAttr.Position == position)
                        {
                            return prop.GetValue(segmentObject);
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }

            return null;
        }

        private static object GetPropertyValue(object obj, string propertyName)
        {
            if (obj == null) return null;

            var property = obj.GetType().GetProperty(propertyName);
            return property?.GetValue(obj);
        }

        private static Dictionary<int, object> GetAllPositionsFromSegment(object obj, string segmentCode)
        {
            var result = new Dictionary<int, object>();
            if (obj == null) return result;

            // Find the segment in the object
            var segmentObject = FindSegmentInObject(obj, segmentCode);
            if (segmentObject == null) return result;

            // Get all positions from the segment
            var properties = segmentObject.GetType().GetProperties();
            foreach (var prop in properties)
            {
                try
                {
                    var positionAttrs = prop.GetCustomAttributes(typeof(PositionAttribute), false);
                    if (positionAttrs.Length > 0 && positionAttrs[0] is PositionAttribute positionAttr)
                    {
                        var value = prop.GetValue(segmentObject);
                        if (value != null)
                        {
                            result[positionAttr.Position] = value;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }

            return result;
        }

        private static object FindSegmentInObject(object obj, string segmentCode)
        {
            if (obj == null) return null;

            // Check if this object itself is the segment
            if (obj.GetType().Name.StartsWith(segmentCode + "_"))
            {
                return obj;
            }

            // Search through properties
            var properties = obj.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(obj);
                if (propValue == null) continue;

                // Check if property type is the segment
                if (prop.PropertyType.Name.StartsWith(segmentCode + "_"))
                {
                    return propValue;
                }

                // Check collections
                if (IsCollection(prop.PropertyType))
                {
                    var enumerable = (System.Collections.IEnumerable)propValue;
                    foreach (var item in enumerable)
                    {
                        if (item?.GetType().Name.StartsWith(segmentCode + "_") == true)
                        {
                            return item;
                        }
                        else if (item != null)
                        {
                            var result = FindSegmentInObject(item, segmentCode);
                            if (result != null) return result;
                        }
                    }
                }

                // Check nested objects
                if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                {
                    var result = FindSegmentInObject(propValue, segmentCode);
                    if (result != null) return result;
                }
            }

            return null;
        }

        #endregion
    }
}

