using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Eddy.Core.Attributes;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.x12;

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

    public static EdiX12Segment Parse(string version, string line, MapOptions mapOptions)
    {
        var identifier = line.Substring(0, line.IndexOf(mapOptions.Separator));
        return Map.MapObject(GetSegmentFor(version, identifier), line, mapOptions);
    }

    public static Type GetSegmentFor(string version, string identifier)
    {
        // if (!_parsers.Value.ContainsKey(identifier))
        //     return typeof(Unkown_Segment);

        return _parsers.Value[version + "." + identifier];
    }

    /// <summary>Like GetSegmentFor, but returns false instead of throwing when the segment is not registered for the version.</summary>
    public static bool TryGetSegmentFor(string version, string identifier, out Type type)
    {
        return _parsers.Value.TryGetValue(version + "." + identifier, out type);
    }

    public static Dictionary<string, Type> LoadSegmentProviders()
    {
        var currentNamespace = typeof(x12Document).Namespace;
        var assembly = typeof(x12Document).Assembly;

        var segmentProviders = assembly.GetTypes()
            .Where(t => t.Namespace != null && t.GetCustomAttributes<Segment>().Count() != 0 && t.Namespace.StartsWith(currentNamespace, StringComparison.Ordinal));

        var matches = new Dictionary<string, Type>();
        foreach (var segmentProvider in segmentProviders)
        {
            var name = segmentProvider.GetCustomAttribute<Segment>().Name;
            var version = segmentProvider.Namespace.Substring(segmentProvider.Namespace.LastIndexOf(".")+2); //+2 to get rid of .v in .v8010
            if (!matches.ContainsKey(version + "." + name))
                matches.Add(version + "." + name, segmentProvider);
        }

        return matches;
    }
}