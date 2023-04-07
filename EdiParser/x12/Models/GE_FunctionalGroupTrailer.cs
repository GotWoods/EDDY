using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("GE")]
public class GE_FunctionalGroupTrailer : EdiX12Segment
{
    [Position(01)]
    public int? NumberOfTransactionSetsIncluded { get; set; }

    [Position(02)]
    public int? GroupControlNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<GE_FunctionalGroupTrailer>(this);
        validator.Required(x => x.NumberOfTransactionSetsIncluded);
        validator.Required(x => x.GroupControlNumber);
        validator.Length(x => x.NumberOfTransactionSetsIncluded, 1, 6);
        validator.Length(x => x.GroupControlNumber, 1, 9);
        return validator.Results;
    }
}