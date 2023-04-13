using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("FPT")]
public class FPT_FinancialParticipation : EdiX12Segment
{
	[Position(01)]
	public string TypeOfAccountCode { get; set; }

	[Position(02)]
	public decimal? PercentageAsDecimal { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FPT_FinancialParticipation>(this);
		validator.Required(x=>x.TypeOfAccountCode);
		validator.Length(x => x.TypeOfAccountCode, 2);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		return validator.Results;
	}
}
