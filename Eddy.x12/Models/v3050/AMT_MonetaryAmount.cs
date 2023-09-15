using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("AMT")]
public class AMT_MonetaryAmount : EdiX12Segment
{
	[Position(01)]
	public string AmountQualifierCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string CreditDebitFlagCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AMT_MonetaryAmount>(this);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		return validator.Results;
	}
}
