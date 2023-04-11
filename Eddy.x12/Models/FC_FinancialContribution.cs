using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("FC")]
public class FC_FinancialContribution : EdiX12Segment
{
	[Position(01)]
	public string ContributionCode { get; set; }

	[Position(02)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public int? Number { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FC_FinancialContribution>(this);
		validator.Required(x=>x.ContributionCode);
		validator.Length(x => x.ContributionCode, 2);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
