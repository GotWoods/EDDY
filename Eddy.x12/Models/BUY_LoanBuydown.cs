using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BUY")]
public class BUY_LoanBuydown : EdiX12Segment
{
	[Position(01)]
	public string LoanBuydownTypeCode { get; set; }

	[Position(02)]
	public string SourceOfFundsCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(05)]
	public decimal? PercentageAsDecimal2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BUY_LoanBuydown>(this);
		validator.Required(x=>x.LoanBuydownTypeCode);
		validator.Required(x=>x.SourceOfFundsCode);
		validator.Length(x => x.LoanBuydownTypeCode, 1);
		validator.Length(x => x.SourceOfFundsCode, 1);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.PercentageAsDecimal2, 1, 10);
		return validator.Results;
	}
}
