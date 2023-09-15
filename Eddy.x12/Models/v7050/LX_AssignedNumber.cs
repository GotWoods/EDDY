using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7050;

[Segment("LX")]
public class LX_TransactionSetLineNumber : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LX_TransactionSetLineNumber>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Length(x => x.AssignedNumber, 1, 9);
		return validator.Results;
	}
}
