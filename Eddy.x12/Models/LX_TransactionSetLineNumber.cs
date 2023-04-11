using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("LX")]
public class LX_TransactionSetLineNumber: EdiX12Segment
{
	[Position(01)]
    public string AssignedNumber { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<LX_TransactionSetLineNumber>(this);
        validator.Length(x => x.AssignedNumber, 1, 9);
        return validator.Results;
    }

    
}