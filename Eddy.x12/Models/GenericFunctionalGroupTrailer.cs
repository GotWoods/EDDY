using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("GE")]
public class GenericFunctionalGroupTrailer : EdiX12Segment
{
    [Position(01)]
    public int? NumberOfTransactionSetsIncluded { get; set; }

    [Position(02)]
    public int? GroupControlNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<GenericFunctionalGroupTrailer>(this);
        validator.Required(x => x.NumberOfTransactionSetsIncluded);
        validator.Required(x => x.GroupControlNumber);
        validator.Length(x => x.NumberOfTransactionSetsIncluded, 1, 6);
        validator.Length(x => x.GroupControlNumber, 1, 9);
        return validator.Results;
    }
}