using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("IEA")]
public class GenericInterchangeControlTrailer : EdiX12Segment
{
    [Position(01)]
    public int? NumberOfIncludedFunctionalGroups { get; set; }

    [Position(02)]
    public string InterchangeControlNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<GenericInterchangeControlTrailer>(this);
        validator.Required(x => x.NumberOfIncludedFunctionalGroups);
        validator.Required(x => x.InterchangeControlNumber);
        validator.Length(x => x.NumberOfIncludedFunctionalGroups, 1, 5);
        validator.Length(x => x.InterchangeControlNumber, 9);
        return validator.Results;
    }
}