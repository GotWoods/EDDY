using System.Collections.Generic;

namespace Eddy.Core;

/// <summary>One control-count or control-number field that RecalculateControlCounts found to be wrong (or
/// missing) on a trailer segment, shared between Eddy.x12's SE/GE/IEA and Eddy.Edifact's UNT/UNE/UNZ.</summary>
public class ControlCountChange
{
    /// <summary>The trailer segment's identifier, e.g. "SE", "GE", "IEA", "UNT", "UNE", "UNZ".</summary>
    public string Trailer { get; set; }

    /// <summary>1-based segment line number of the trailer, matching <see cref="SegmentSource.LineNumber"/>.
    /// When the trailer itself is missing this is the best available line number for where it belongs
    /// (typically its container's header).</summary>
    public int LineNumber { get; set; }

    /// <summary>The trailer property that changed, e.g. "NumberOfIncludedSegments",
    /// "TransactionSetControlNumber", "NumberOfTransactionSetsIncluded", "GroupControlNumber",
    /// "NumberOfIncludedFunctionalGroups", "InterchangeControlNumber" (x12) or "NumberOfSegmentsInMessage",
    /// "MessageReferenceNumber", "NumberOfMessages", "FunctionalGroupReferenceNumber",
    /// "InterchangeControlCount", "InterchangeControlReference" (EDIFACT).</summary>
    public string Field { get; set; }

    /// <summary>The value found in the file, or null when the trailer itself was missing.</summary>
    public string OldValue { get; set; }

    /// <summary>The correct value.</summary>
    public string NewValue { get; set; }
}

/// <summary>Result of recalculating a document's control counts/numbers: the (possibly unchanged) text and
/// every field that was found to be wrong or missing.</summary>
public class ControlCountResult
{
    /// <summary>The input text with every incorrect trailer field corrected in place. Equal to the original
    /// input when <see cref="Changes"/> is empty.</summary>
    public string Text { get; set; }

    public List<ControlCountChange> Changes { get; set; } = new List<ControlCountChange>();
}
