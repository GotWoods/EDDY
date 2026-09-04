using System.Collections.Generic;
using Eddy.x12.Models;

namespace Eddy.x12;

/// <summary>One ISA...IEA interchange within a document. A single file can contain several of these back to back.</summary>
public class x12Interchange
{
    public GenericInterchangeControlHeader Header { get; set; }

    /// <summary>The IEA segment that closed this interchange, or null if it was never found (missing trailer).</summary>
    public GenericInterchangeControlTrailer Trailer { get; set; }

    public List<x12FunctionalGroup> FunctionalGroups { get; set; } = new();

    /// <summary>Segments that appeared directly inside the interchange but outside of any GS/GE functional group.</summary>
    public List<EdiX12Segment> OrphanSegments { get; set; } = new();
}
