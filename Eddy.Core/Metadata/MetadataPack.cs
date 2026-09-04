using System.Collections.Generic;
using System.IO;

namespace Eddy.Core.Metadata;

/// <summary>
/// A metadata pack loaded from JSON. See docs/metadata-packs.md for the format.
/// Implements <see cref="IMetadataSource"/> for exactly one (standard, version).
/// </summary>
public class MetadataPack : IMetadataSource
{
    public const string FormatId = "eddy-metadata-pack/1";

    public string Name { get; set; }
    public string Standard { get; set; }
    public string Version { get; set; }
    public string Provenance { get; set; }
    public string License { get; set; }

    public Dictionary<string, DataElementDefinition> DataElements { get; } = new Dictionary<string, DataElementDefinition>();
    public Dictionary<string, SegmentDefinition> Segments { get; } = new Dictionary<string, SegmentDefinition>();
    public Dictionary<string, SegmentDefinition> Composites { get; } = new Dictionary<string, SegmentDefinition>();
    public Dictionary<string, Dictionary<string, string>> Codes { get; } = new Dictionary<string, Dictionary<string, string>>();

    public IReadOnlyList<KeyValuePair<string, string>> Versions =>
        new[] { new KeyValuePair<string, string>(Standard, Version) };

    public static MetadataPack Load(string path)
    {
        using (var stream = File.OpenRead(path))
            return Load(stream);
    }

    public static MetadataPack Load(Stream stream)
    {
        // TODO(core-metadata): parse per docs/metadata-packs.md. Reject a missing or different "format".
        throw new System.NotImplementedException();
    }

    public void Save(string path)
    {
        using (var stream = File.Create(path))
            Save(stream);
    }

    public void Save(Stream stream)
    {
        // TODO(core-metadata): write the JSON form, indented, keys sorted, so packs diff cleanly.
        throw new System.NotImplementedException();
    }

    /// <summary>Copies everything from <paramref name="other"/> into this pack; other's values win on conflict.</summary>
    public void MergeFrom(MetadataPack other)
    {
        // TODO(core-metadata)
        throw new System.NotImplementedException();
    }

    public SegmentDefinition GetSegment(string standard, string version, string id)
    {
        // TODO(core-metadata): segments first, then composites.
        throw new System.NotImplementedException();
    }

    public DataElementDefinition GetDataElement(string standard, string version, string dataElementNumber)
    {
        throw new System.NotImplementedException();
    }

    public IReadOnlyDictionary<string, string> GetCodes(string standard, string version, string dataElementNumber)
    {
        throw new System.NotImplementedException();
    }
}
