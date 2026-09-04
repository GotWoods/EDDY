using System.Collections.Generic;

namespace Eddy.Core.Metadata;

/// <summary>
/// A provider of standard metadata for one or more (standard, version) pairs. Implementations must be
/// thread-safe for reads. Version arguments are already normalised by the catalog ("004010", "D96A").
/// </summary>
public interface IMetadataSource
{
    /// <summary>Short name shown as the origin of values this source provides.</summary>
    string Name { get; }

    /// <summary>The (standard, version) pairs this source has data for.</summary>
    IReadOnlyList<KeyValuePair<string, string>> Versions { get; }

    /// <summary>Segment or composite definition by identifier, or null.</summary>
    SegmentDefinition GetSegment(string standard, string version, string id);

    /// <summary>Data dictionary entry by data element number, or null.</summary>
    DataElementDefinition GetDataElement(string standard, string version, string dataElementNumber);

    /// <summary>Code list for a data element number (code to description, description may be ""), or null.</summary>
    IReadOnlyDictionary<string, string> GetCodes(string standard, string version, string dataElementNumber);
}
