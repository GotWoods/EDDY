using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("F05")]
public class F05_AllowanceChargeClaim : EdiX12Segment
{
	[Position(01)]
	public string ChargeAllowanceQualifier { get; set; }

	[Position(02)]
	public string Amount { get; set; }

	[Position(03)]
	public string CreditDebitFlagCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F05_AllowanceChargeClaim>(this);
		validator.Required(x=>x.ChargeAllowanceQualifier);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.Length(x => x.ChargeAllowanceQualifier, 2);
		validator.Length(x => x.Amount, 1, 9);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		return validator.Results;
	}
}
