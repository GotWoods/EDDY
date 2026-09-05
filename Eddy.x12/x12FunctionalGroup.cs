using System.Collections.Generic;
using Eddy.x12.Models;

namespace Eddy.x12;

/// <summary>One GS...GE functional group within an interchange. An interchange can contain several of these.</summary>
public class x12FunctionalGroup
{
    /// <summary>Null when a GS record was expected but not found (lenient mode only).</summary>
    public GenericFunctionalGroupHeader Header { get; set; }

    /// <summary>The GE segment that closed this group, or null if it was never found (missing trailer).</summary>
    public GenericFunctionalGroupTrailer Trailer { get; set; }

    public List<Section> Sections { get; set; } = new();

    /// <summary>Segments that appeared directly inside the group but outside of any ST/SE transaction set.</summary>
    public List<EdiX12Segment> OrphanSegments { get; set; } = new();
}
