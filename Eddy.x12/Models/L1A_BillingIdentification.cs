using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("L1A")]
public class L1A_BillingIdentification : EdiX12Segment
{
	[Position(01)]
	public string Amount { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L1A_BillingIdentification>(this);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
