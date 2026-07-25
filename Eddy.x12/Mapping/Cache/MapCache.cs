using System;
using System.Collections.Concurrent;
using System.Text;

namespace Eddy.x12.Mapping.Cache
{
    internal static class MapCache
    {
        private static readonly ConcurrentDictionary<Type, RepresentationMap> _segmentMapCache = new();

        // The old lock only serialized the writers, so two callers that both missed on
        // TryGetValue still both reached Add and the second threw "An item with the same
        // key has already been added" -- and the unsynchronized read raced the write
        // besides. GetOrAdd covers both; RepresentationMap.From is pure reflection over t,
        // so running it twice under contention costs nothing but the wasted call.
        public static RepresentationMap GetMap(Type t) => _segmentMapCache.GetOrAdd(t, RepresentationMap.From);
    }
}
