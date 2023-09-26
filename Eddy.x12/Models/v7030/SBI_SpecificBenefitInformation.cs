using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7030;

[Segment("SBI")]
public class SBI_SpecificBenefitInformation : EdiX12Segment
{
	[Position(01)]
	public string EligibilityOrBenefitInformationCode { get; set; }

	[Position(02)]
	public string TimePeriodQualifier { get; set; }

	[Position(03)]
	public int? NumberOfPeriods { get; set; }

	[Position(04)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public int? TierIdentifier { get; set; }

	[Position(08)]
	public string PlanCoverageDescription { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(11)]
	public decimal? MonetaryAmount3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SBI_SpecificBenefitInformation>(this);
		validator.Required(x=>x.EligibilityOrBenefitInformationCode);
		validator.ARequiresB(x=>x.NumberOfPeriods, x=>x.TimePeriodQualifier);
		validator.Length(x => x.EligibilityOrBenefitInformationCode, 1, 2);
		validator.Length(x => x.TimePeriodQualifier, 1, 2);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.TierIdentifier, 1, 2);
		validator.Length(x => x.PlanCoverageDescription, 1, 50);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		return validator.Results;
	}
}
