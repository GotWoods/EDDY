using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("A2")]
public class A2_AcceptanceDetail : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetControlNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<A2_AcceptanceDetail>(this);
		validator.Required(x=>x.TransactionSetControlNumber);
		validator.Length(x => x.TransactionSetControlNumber, 4, 9);
		return validator.Results;
	}
}
