using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("TRS")]
public class TRS_TaxRate : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string FreeFormDescription { get; set; }

	[Position(03)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string RateApplicationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRS_TaxRate>(this);
		validator.Required(x=>x.ActionCode);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.RateApplicationCode, 2);
		return validator.Results;
	}
}
