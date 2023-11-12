using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("BUY")]
public class BUY_LoanBuydown : EdiX12Segment
{
	[Position(01)]
	public string LoanBuydownTypeCode { get; set; }

	[Position(02)]
	public string BuydownSourceCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	[Position(05)]
	public decimal? Percent2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BUY_LoanBuydown>(this);
		validator.Required(x=>x.LoanBuydownTypeCode);
		validator.Required(x=>x.BuydownSourceCode);
		validator.Length(x => x.LoanBuydownTypeCode, 1);
		validator.Length(x => x.BuydownSourceCode, 1);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.Percent2, 1, 10);
		return validator.Results;
	}
}
