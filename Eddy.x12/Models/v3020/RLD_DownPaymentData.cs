using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("RLD")]
public class RLD_DownPaymentData : EdiX12Segment
{
	[Position(01)]
	public string TypeOfDownpaymentCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RLD_DownPaymentData>(this);
		validator.Length(x => x.TypeOfDownpaymentCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
