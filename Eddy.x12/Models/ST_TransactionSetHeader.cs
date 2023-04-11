using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("ST")]
public class ST_TransactionSetHeader : EdiX12Segment
{
    [Position(1)]
    public string TransactionSetIdentifierCode { get; set; }
    
    [Position(2)]
    public string TransactionSetControlNumber { get; set; }
    
    [Position(3)]
    public string ImplementationConventionReference { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<ST_TransactionSetHeader>(this);
        validator.Required(x => x.TransactionSetIdentifierCode);
        validator.Required(x => x.TransactionSetControlNumber);
        validator.Length(x => x.TransactionSetIdentifierCode, 3);
        validator.Length(x => x.TransactionSetControlNumber, 4, 9);
        validator.Length(x => x.ImplementationConventionReference, 1, 35);
        return validator.Results;
    }

    
}