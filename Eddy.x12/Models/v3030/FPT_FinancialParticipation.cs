using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("FPT")]
public class FPT_FinancialParticipation : EdiX12Segment
{
	[Position(01)]
	public string TypeOfAccount { get; set; }

	[Position(02)]
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FPT_FinancialParticipation>(this);
		validator.Required(x=>x.TypeOfAccount);
		validator.Length(x => x.TypeOfAccount, 2);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}
