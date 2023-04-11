using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("AK2")]
public class AK2_TransactionSetResponseHeader : EdiX12Segment
{
    [Position(01)]
    public string TransactionSetIdentifierCode { get; set; }

    [Position(02)]
    public string TransactionSetControlNumber { get; set; }

    [Position(03)]
    public string ImplementationConventionReference { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AK2_TransactionSetResponseHeader>(this);
        validator.Required(x => x.TransactionSetIdentifierCode);
        validator.Required(x => x.TransactionSetControlNumber);
        validator.Length(x => x.TransactionSetIdentifierCode, 3);
        validator.Length(x => x.TransactionSetControlNumber, 4, 9);
        validator.Length(x => x.ImplementationConventionReference, 1, 35);
        return validator.Results;
    }
}