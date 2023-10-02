using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.x12;

public class EdiSectionParserFactory
{
    private static bool _isInitialized = false;
    private static Dictionary<string, Type> _parsers;

    public static EdiX12Segment Parse(string version, string line, MapOptions mapOptions)
    {
        var identifier = line.Substring(0, line.IndexOf(mapOptions.Separator));
        return Map.MapObject(GetSegmentFor(version, identifier), line, mapOptions);
    }

    public static Type GetSegmentFor(string version, string identifier)
    {
        if (!_isInitialized)
        {
            _parsers = LoadSegmentProviders();
            _isInitialized = true;
        }

        // if (!_parsers.ContainsKey(identifier))
        //     return typeof(Unkown_Segment);

        return _parsers[version + "." + identifier];
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
            matches.Add(version + "." + name, segmentProvider);
        }

        return matches;
    }
}