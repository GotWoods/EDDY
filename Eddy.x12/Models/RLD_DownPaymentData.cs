using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("RLD")]
public class RLD_DownPaymentData : EdiX12Segment
{
	[Position(01)]
	public string TypeOfFundsCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string AmountQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RLD_DownPaymentData>(this);
		validator.ARequiresB(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.Length(x => x.TypeOfFundsCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		return validator.Results;
	}
}
