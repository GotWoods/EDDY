using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030.Composites;

namespace Eddy.x12.Models.v7030;

[Segment("EB")]
public class EB_EligibilityOrBenefitInformation : EdiX12Segment
{
	[Position(01)]
	public string EligibilityOrBenefitInformationCode { get; set; }

	[Position(02)]
	public string CoverageLevelCode { get; set; }

	[Position(03)]
	public C064_ServiceType ServiceType { get; set; }

	[Position(04)]
	public string InsuranceProductCode { get; set; }

	[Position(05)]
	public string PlanCoverageDescription { get; set; }

	[Position(06)]
	public string TimePeriodQualifier { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount { get; set; }

	[Position(08)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(09)]
	public string QuantityQualifier { get; set; }

	[Position(10)]
	public decimal? Quantity { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(12)]
	public string NetworkIndicatorCode { get; set; }

	[Position(13)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(14)]
	public int? DiagnosisCodePointer { get; set; }

	[Position(15)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(16)]
	public string HealthCareServicesReviewRequirementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EB_EligibilityOrBenefitInformation>(this);
		validator.Required(x=>x.EligibilityOrBenefitInformationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityQualifier, x=>x.Quantity);
		validator.Length(x => x.EligibilityOrBenefitInformationCode, 1, 2);
		validator.Length(x => x.CoverageLevelCode, 3);
		validator.Length(x => x.InsuranceProductCode, 1, 3);
		validator.Length(x => x.PlanCoverageDescription, 1, 50);
		validator.Length(x => x.TimePeriodQualifier, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.NetworkIndicatorCode, 1, 2);
		validator.Length(x => x.DiagnosisCodePointer, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.HealthCareServicesReviewRequirementCode, 1, 2);
		return validator.Results;
	}
}
