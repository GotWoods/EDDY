using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact;

/// <summary>UNZ - Interchange Control Trailer.</summary>
[Segment("UNZ")]
public class GenericInterchangeControlTrailer : EdifactSegment
{
    [Position(1)]
    public string InterchangeControlCount { get; set; }

    [Position(2)]
    public string InterchangeControlReference { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<GenericInterchangeControlTrailer>(this);
        validator.Required(x => x.InterchangeControlCount);
        validator.Required(x => x.InterchangeControlReference);
        validator.Length(x => x.InterchangeControlCount, 1, 6);
        validator.Length(x => x.InterchangeControlReference, 1, 14);
        return validator.Results;
    }
}
