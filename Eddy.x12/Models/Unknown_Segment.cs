using System.Collections.Generic;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

/// <summary>
/// Stand-in for a segment whose identifier is not registered for the document's version. Produced only
/// in lenient parsing; strict parsing throws InvalidFileFormatException instead.
/// </summary>
public class Unknown_Segment : EdiX12Segment
{
    public string SegmentId { get; set; }
    public List<string> Elements { get; set; } = new();

    /// <summary>The version the document was being parsed as, used to build the Validate() error message.</summary>
    public string Version { get; set; }

    public override ValidationResult Validate()
    {
        var result = new ValidationResult();
        result.Add(new Error(ErrorCodes.UnknownSegment, SegmentId, Version));
        return result;
    }
}
