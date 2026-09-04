using System.Collections.Generic;
using Eddy.Core.Validation;

namespace Eddy.Edifact;

/// <summary>Stand-in for a segment identifier that is not defined in the resolved standards version. Used
/// only when parsing with <see cref="EdifactParseOptions.Lenient"/> set; in the default (strict) mode an
/// unknown segment throws instead. Keeps the raw, unescaped element values so a caller can still inspect
/// (or re-serialize) the data even though its shape is not known.</summary>
public class Unknown_Segment : EdifactSegment
{
    public string SegmentId { get; set; }

    public List<string> Elements { get; set; } = new List<string>();

    /// <summary>The standards version segments were being read as when this was encountered.</summary>
    public string Version { get; set; }

    public override ValidationResult Validate()
    {
        var result = new ValidationResult { SegmentCode = SegmentId };
        result.Add(new Error(ErrorCodes.EdiFactUnknownSegment, SegmentId, Version));
        return result;
    }
}
