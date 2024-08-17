using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Eddy.Core.Attributes;
using Eddy.Edifact.Mapping;

namespace Eddy.Edifact;


//TODO: this almost matches the x12EdiSectionParserFactory and can probably be refactored into the core
public class EdiSectionParserFactory
{
    private static bool _isInitialized = false;
    private static Dictionary<string, Type> _parsers;

    public static EdifactSegment Parse(string version, string line, MapOptions mapOptions)
    {
        if (line.IndexOf(mapOptions.Separator) == -1)
            return null;
        var identifier = line.Substring(0, line.IndexOf(mapOptions.Separator));
        return (EdifactSegment)Map.MapObject(GetSegmentFor(version, identifier), line, mapOptions);
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