using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.x12.Mapping.Cache
{
    internal static class MapCache
    {
        private static readonly Dictionary<Type, RepresentationMap> _segmentMapCache = new();
        public static RepresentationMap GetMap(Type t)
        {
            if (_segmentMapCache.TryGetValue(t, out var map))
                return map;

            var rep = RepresentationMap.From(t);
            _segmentMapCache.Add(t, rep);
            return rep;
        }
    }
}
