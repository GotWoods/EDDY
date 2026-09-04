using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Eddy.Core.Attributes;
using Eddy.Edifact.Mapping;

namespace Eddy.Edifact;

public class EdiSectionParserFactory
{
    // This used to be a bool flag plus a field, assigned in that order with no barrier
    // between them. Concurrent callers could each run LoadSegmentProviders (which reflects
    // over every type in the assembly), and on a weak memory model a caller could observe
    // the flag set while the field was still null. Lazy builds the dictionary once and
    // publishes it only when it is complete; nothing mutates it afterwards, so the reads
    // below need no further synchronization.
    private static readonly Lazy<Dictionary<string, Type>> _parsers =
        new Lazy<Dictionary<string, Type>>(LoadSegmentProviders, LazyThreadSafetyMode.ExecutionAndPublication);

    /// <summary>Parses <paramref name="line"/> as a segment of the given version. Returns null when the
    /// line has no data elements at all, or when <paramref name="version"/>/identifier is not known -
    /// callers decide how to handle an unrecognized segment (throw, or record it and move on).</summary>
    public static EdifactSegment Parse(string version, string line, MapOptions mapOptions)
    {
        var separatorIndex = line.IndexOf(mapOptions.Separator, StringComparison.Ordinal);
        var identifier = separatorIndex == -1 ? line : line.Substring(0, separatorIndex);
        var type = GetSegmentFor(version, identifier);
        if (type == null)
            return null;
        return (EdifactSegment)Map.MapObject(type, line, mapOptions);
    }

    /// <summary>Returns the model type for <paramref name="identifier"/> in <paramref name="version"/>, or
    /// null when that version/segment combination is not defined.</summary>
    public static Type GetSegmentFor(string version, string identifier)
    {
        _parsers.Value.TryGetValue(version + "." + identifier, out var type);
        return type;
    }

    public static Dictionary<string, Type> LoadSegmentProviders()
    {
        var currentNamespace = typeof(EdiFactDocument).Namespace;
        var assembly = typeof(EdiFactDocument).Assembly;

        var segmentProviders = assembly.GetTypes()
            .Where(t => t.Namespace != null && t.GetCustomAttributes<Segment>().Count() != 0 && t.Namespace.StartsWith(currentNamespace, StringComparison.Ordinal));

        var matches = new Dictionary<string, Type>();
        foreach (var segmentProvider in segmentProviders)
        {
            var name = segmentProvider.GetCustomAttribute<Segment>().Name;
            var version = segmentProvider.Namespace.Substring(segmentProvider.Namespace.LastIndexOf(".") + 1); //this is a slight variance over x12
            if (!matches.ContainsKey(version + "." + name))
                matches.Add(version + "." + name, segmentProvider);
        }

        return matches;
    }
}
