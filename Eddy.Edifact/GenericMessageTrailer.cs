using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact;

/// <summary>UNT - Message Trailer.</summary>
[Segment("UNT")]
public class GenericMessageTrailer : EdifactSegment
{
    [Position(1)]
    public string NumberOfSegmentsInMessage { get; set; }

    [Position(2)]
    public string MessageReferenceNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<GenericMessageTrailer>(this);
        validator.Required(x => x.NumberOfSegmentsInMessage);
        validator.Required(x => x.MessageReferenceNumber);
        validator.Length(x => x.NumberOfSegmentsInMessage, 1, 10);
        validator.Length(x => x.MessageReferenceNumber, 1, 14);
        return validator.Results;
    }
}
