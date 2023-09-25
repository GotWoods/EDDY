using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("FC")]
public class FC_FinancialContribution : EdiX12Segment
{
	[Position(01)]
	public string ContributionCode { get; set; }

	[Position(02)]
	public decimal? Percent { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FC_FinancialContribution>(this);
		validator.Required(x=>x.ContributionCode);
		validator.Length(x => x.ContributionCode, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		return validator.Results;
	}
}
