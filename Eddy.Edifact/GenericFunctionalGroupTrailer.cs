using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact;

/// <summary>UNE - Functional Group Trailer.</summary>
[Segment("UNE")]
public class GenericFunctionalGroupTrailer : EdifactSegment
{
    [Position(1)]
    public string NumberOfMessages { get; set; }

    [Position(2)]
    public string FunctionalGroupReferenceNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<GenericFunctionalGroupTrailer>(this);
        validator.Required(x => x.NumberOfMessages);
        validator.Required(x => x.FunctionalGroupReferenceNumber);
        validator.Length(x => x.NumberOfMessages, 1, 6);
        validator.Length(x => x.FunctionalGroupReferenceNumber, 1, 14);
        return validator.Results;
    }
}
