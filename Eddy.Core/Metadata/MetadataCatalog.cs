using System;
using System.Collections.Generic;

namespace Eddy.Core.Metadata;

/// <summary>
/// Combines derived metadata with any number of packs. Thread-safe. Describe() results are cached per
/// type and invalidated when a source is added.
/// </summary>
public class MetadataCatalog
{
    /// <summary>A process-wide catalog for callers that do not manage their own.</summary>
    public static MetadataCatalog Default { get; } = new MetadataCatalog();

    public IReadOnlyList<IMetadataSource> Sources
    {
        get { throw new NotImplementedException(); }
    }

    public void AddSource(IMetadataSource source)
    {
        // TODO(core-metadata): later sources overlay earlier ones.
        throw new NotImplementedException();
    }

    public void AddPack(MetadataPack pack) => AddSource(pack);

    /// <summary>Loads every *.json file in the directory as a pack; files that are not packs are skipped and reported in the return value.</summary>
    public IReadOnlyList<string> AddPacksFromDirectory(string directory)
    {
        throw new NotImplementedException();
    }

    /// <summary>Derived metadata for the type, overlaid with every matching pack. Never null for a type with [Position] properties.</summary>
    public SegmentDefinition Describe(Type segmentType)
    {
        throw new NotImplementedException();
    }

    /// <summary>Pack definition for a segment identifier without a model type, or null when no pack has it.</summary>
    public SegmentDefinition GetSegment(string standard, string version, string id)
    {
        throw new NotImplementedException();
    }

    public DataElementDefinition GetDataElement(string standard, string version, string dataElementNumber)
    {
        throw new NotImplementedException();
    }

    /// <summary>Description of a code value for a data element, or null when no loaded pack knows it.</summary>
    public string DescribeCode(string standard, string version, string dataElementNumber, string code)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyDictionary<string, string> GetCodes(string standard, string version, string dataElementNumber)
    {
        throw new NotImplementedException();
    }

    /// <summary>"4010", "00401" and "004010" all become "004010"; EDIFACT versions are upper-cased ("d96a" to "D96A").</summary>
    public static string NormalizeVersion(string standard, string version)
    {
        throw new NotImplementedException();
    }
}
