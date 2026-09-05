using System;
using System.Collections.Concurrent;

namespace Eddy.Edifact.Mapping.Cache
{
    internal static class MapCache
    {
        private static readonly ConcurrentDictionary<Type, RepresentationMap> _segmentMapCache = new();

        // Same fix as Eddy.x12: the previous lock only serialized writers, so two callers that both
        // missed on TryGetValue still both reached Add, and the unsynchronized read raced the write.
        // GetOrAdd covers both; RepresentationMap.From is pure reflection, so a duplicate call under
        // contention costs nothing but the wasted work.
        public static RepresentationMap GetMap(Type t) => _segmentMapCache.GetOrAdd(t, RepresentationMap.From);
    }
}
