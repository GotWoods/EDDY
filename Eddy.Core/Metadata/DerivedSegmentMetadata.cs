using System;

namespace Eddy.Core.Metadata;

/// <summary>
/// Computes a <see cref="SegmentDefinition"/> from a model type alone, with no data files: positions and
/// names from the [Position] properties, coarse data types from the CLR property types, and required,
/// length and date/time rules by probing the type's Validate() method. Results are cached per type.
/// </summary>
public static class DerivedSegmentMetadata
{
    /// <summary>
    /// Describes <paramref name="segmentType"/>. <paramref name="standard"/> and <paramref name="version"/>
    /// are recorded on the result; pass what the caller knows (the catalog infers them from the
    /// namespace when null: "Eddy.x12.Models.v4010" gives X12/004010, "Eddy.Edifact.Models.D96A" gives EDIFACT/D96A).
    /// </summary>
    public static SegmentDefinition Describe(Type segmentType, string standard = null, string version = null)
    {
        // TODO(core-metadata): see docs/metadata-packs.md, "Derived metadata".
        throw new NotImplementedException();
    }

    /// <summary>Infers ("X12", "004010") or ("EDIFACT", "D96A") from a model type's namespace, or (null, null).</summary>
    public static void InferStandardAndVersion(Type modelType, out string standard, out string version)
    {
        // TODO(core-metadata)
        throw new NotImplementedException();
    }
}
