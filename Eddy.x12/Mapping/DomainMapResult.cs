using System.Collections.Generic;
using Eddy.Core;
using Eddy.x12.Models;

namespace Eddy.x12.Mapping;

/// <summary>One thing <see cref="DomainMapper.MapWithDiagnostics{T}"/> noticed while walking segments into
/// a domain object: either the segment that stopped the walk (it did not match any property still expected
/// at that point) or a segment left over after the walk stopped.</summary>
public class DomainMapDiagnostic
{
    public EdiX12Segment Segment { get; set; }

    /// <summary>Where the segment came from, or null when it was not source-tracked.</summary>
    public SegmentSource Source { get; set; }

    public string Message { get; set; }
}

/// <summary>Result of <see cref="DomainMapper.MapWithDiagnostics{T}"/>/<see cref="DomainMapper.MapWithDiagnostics"/>:
/// the mapped object plus everything that was left unconsumed.</summary>
public class DomainMapResult<T>
{
    public T Value { get; set; }

    /// <summary>Every segment from the input that was not consumed while mapping <see cref="Value"/>, in
    /// their original order.</summary>
    public List<EdiX12Segment> UnmappedSegments { get; set; } = new List<EdiX12Segment>();

    /// <summary>One diagnostic for the segment that stopped the walk (if any were left over), followed by
    /// one "not mapped" diagnostic per remaining segment after that.</summary>
    public List<DomainMapDiagnostic> Diagnostics { get; set; } = new List<DomainMapDiagnostic>();

    /// <summary>Every segment instance that WAS consumed while mapping <see cref="Value"/>. Reference-based
    /// (the default EdiX12Segment equality), so a caller can tell mapped from unmapped by identity even
    /// when two segments would otherwise compare equal.</summary>
    public HashSet<EdiX12Segment> ConsumedSegments { get; set; } = new HashSet<EdiX12Segment>();
}
