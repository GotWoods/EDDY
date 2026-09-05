using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Eddy.Core.Attributes;
using Eddy.Core.Codes;
using Eddy.Edifact.Mapping.Cache;

namespace Eddy.Edifact.Mapping;

public class Map
{
    public static object MapObject(Type t, string line, MapOptions options)
    {
        return MapObject(t, line, options.Separator, 0, options);
    }

    public static EdifactSegment MapObject(Type t, string line, string separator, int positionOffset, MapOptions options) //separator is explicit here as we use the regular separator normally but can use the component element separator as well
    {
        var separatorChar = separator.Length > 0 ? separator[0] : '\0';
        var releaseChar = GetReleaseChar(options);

        var values = SplitEscaped(line, separatorChar, releaseChar).Select(x => x.Trim()).ToList();

        var result = (EdifactSegment)Activator.CreateInstance(t);

        var rep = MapCache.GetMap(t);
        foreach (var item in rep.Representations)
        {
            var position = item.Position + positionOffset;
            if (position >= 0 && values.Count > position)
            {
                var propertyValue = values[position];
                if (propertyValue != null && propertyValue.Trim().Length > 0)
                {
                    var underlyingType = Nullable.GetUnderlyingType(item.PropertyInfo.PropertyType) ?? item.PropertyInfo.PropertyType;
                    //composite here
                    if (underlyingType.IsSubclassOf(typeof(EdifactComponent)))
                    {
                        var safeValue = MapObject(underlyingType, propertyValue.Trim(), options.ComponentElementSeparator, -1, options);
                        item.PropertyInfo.SetValue(result, safeValue, null);
                    }
                    else if (IsCodeType(underlyingType))
                    {
                        var safeValue = Activator.CreateInstance(underlyingType, propertyValue);
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
        return (T)Convert.ChangeType(segment, typeof(T));
        ;
    }

    public static T MapComposite<T>(string line, MapOptions options) where T : new()
    {
        var segment = MapObject(typeof(T), line, options.ComponentElementSeparator, -1, options);
        return (T)Convert.ChangeType(segment, typeof(T));
        ;
    }

    /// <summary>Splits <paramref name="line"/> on <paramref name="delimiter"/>, honouring the release
    /// character: a release character immediately followed by this delimiter or by itself is resolved to
    /// that literal character and does not split. A release character followed by some other character
    /// (e.g. the *other* separator, when this call is splitting on elements rather than components) is
    /// left untouched in the output so the split responsible for that character - typically a subsequent
    /// composite split - can resolve it correctly instead of it being consumed here.</summary>
    private static List<string> SplitEscaped(string line, char delimiter, char releaseChar)
    {
        var result = new List<string>();
        if (line == null)
        {
            result.Add(null);
            return result;
        }

        var current = new StringBuilder();
        var i = 0;
        while (i < line.Length)
        {
            var c = line[i];
            if (c == releaseChar && i + 1 < line.Length)
            {
                var next = line[i + 1];
                if (next == delimiter || next == releaseChar)
                {
                    current.Append(next); //resolved to a literal character at this level
                }
                else
                {
                    //not this level's delimiter - leave the escape sequence intact for whichever
                    //split (element vs component) is actually responsible for interpreting it
                    current.Append(c);
                    current.Append(next);
                }
                i += 2;
                continue;
            }

            if (c == delimiter)
            {
                result.Add(current.ToString());
                current.Clear();
                i++;
                continue;
            }

            current.Append(c);
            i++;
        }

        result.Add(current.ToString());
        return result;
    }

    private static char GetReleaseChar(MapOptions options)
    {
        return !string.IsNullOrEmpty(options.ReleaseCharacter) ? options.ReleaseCharacter[0] : '?';
    }

    /// <summary>Splits a raw segment's text (tag included, as position 0) into its unescaped elements,
    /// the same way the tag-driven element split in <see cref="MapObject(Type,string,MapOptions)"/> works.
    /// Used for segments whose shape is not known (e.g. <see cref="Unknown_Segment"/>).</summary>
    public static List<string> SplitElements(string line, MapOptions options)
    {
        return SplitEscaped(line, options.Separator.Length > 0 ? options.Separator[0] : '\0', GetReleaseChar(options))
            .Select(x => x.Trim())
            .ToList();
    }

    /// <summary>Escapes any occurrence of the component separator, element separator, segment terminator
    /// or the release character itself within <paramref name="value"/>, so the result can be safely
    /// embedded back into a segment's text.</summary>
    public static string EscapeValue(string value, MapOptions options)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        var releaseChar = GetReleaseChar(options);
        var special = new[]
        {
            options.ComponentElementSeparator.Length > 0 ? options.ComponentElementSeparator[0] : '\0',
            options.Separator.Length > 0 ? options.Separator[0] : '\0',
            options.LineEnding.Length > 0 ? options.LineEnding[0] : '\0',
            releaseChar
        };

        if (value.IndexOfAny(special) < 0)
            return value;

        var sb = new StringBuilder(value.Length);
        foreach (var c in value)
        {
            if (Array.IndexOf(special, c) >= 0)
                sb.Append(releaseChar);
            sb.Append(c);
        }

        return sb.ToString();
    }

    public static string SegmentToString<T>(T segment, MapOptions options) where T : EdifactSegment
    {
        return SegmentToString(segment, options, true);
    }

    /// <summary>Renders one segment back to text. Handles <see cref="Unknown_Segment"/> (SegmentId followed
    /// by its raw Elements, joined by the separator, with trailing empty elements trimmed) as well as every
    /// segment known to <see cref="MapCache"/>.</summary>
    public static string SegmentToString<T>(T segment, MapOptions options, bool includeTerminator) where T : EdifactSegment
    {
        if (segment is Unknown_Segment unknown)
            return UnknownSegmentToString(unknown, options, includeTerminator);

        var segmentType = segment.GetType().GetCustomAttribute<Segment>();
        var components = ItemToString(segment, options.Separator, options);
        if (string.IsNullOrEmpty(components))
            return "";
        var text = segmentType.Name + options.Separator + components;
        return includeTerminator ? text + options.LineEnding : text;
    }

    private static string UnknownSegmentToString(Unknown_Segment segment, MapOptions options, bool includeTerminator)
    {
        var elements = new List<string>(segment.Elements ?? new List<string>());
        while (elements.Count > 0 && string.IsNullOrEmpty(elements[elements.Count - 1]))
            elements.RemoveAt(elements.Count - 1);

        var text = segment.SegmentId;
        foreach (var element in elements)
        {
            text += options.Separator;
            text += EscapeValue(element, options);
        }

        return includeTerminator ? text + options.LineEnding : text;
    }

    private static string ItemToString(EdifactSegment element, string separator, MapOptions options)
    {
        var rep = MapCache.GetMap(element.GetType());
        if (rep.Representations.Count == 0)
            return "";

        //Position attributes are 1-based (Position(1) is the first element after the segment tag, which
        //MapObject reads from values[1] because values[0] there is the tag itself). There is no tag slot
        //in this array - the tag is prefixed separately by the caller - so positions are shifted down by
        //one to land at 0-based array indices.
        var data = new string[rep.Representations.Last().Position];

        foreach (var item in rep.Representations)
        {
            var position = item.Position - 1;
            var underlyingType = Nullable.GetUnderlyingType(item.PropertyInfo.PropertyType) ?? item.PropertyInfo.PropertyType;

            string propertyValue;
            if (underlyingType.IsSubclassOf(typeof(EdifactComponent)))
            {
                var component = (EdifactComponent)item.PropertyInfo.GetValue(element);
                propertyValue = component != null ? ItemToString(component, options.ComponentElementSeparator, options) : "";
            }
            else
            {
                var raw = item.PropertyInfo.GetValue(element)?.ToString();
                propertyValue = raw != null ? EscapeValue(raw, options) : "";
            }

            data[position] = propertyValue;
        }

        var joined = string.Join(separator, data);
        while (joined.EndsWith(separator))
            joined = joined.Substring(0, joined.Length - separator.Length);
        return joined;
    }

    /// <summary>True for a closed <see cref="Code{TList}"/> type.</summary>
    private static bool IsCodeType(Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Code<>);
    }
}
