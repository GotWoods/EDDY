using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("MIC")]
public class MIC_MortgageInsuranceCoverage : EdiX12Segment
{
	[Position(01)]
	public string MortgageInsuranceApplicationType { get; set; }

	[Position(02)]
	public string MortgageInsuranceCoverageTypeCode { get; set; }

	[Position(03)]
	public string MortgageInsuranceCertificateTypeCode { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	[Position(05)]
	public string PremiumRatePatternCode { get; set; }

	[Position(06)]
	public string MortgageInsuranceDurationCode { get; set; }

	[Position(07)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public string MortgageInsuranceRenewalOptionCode { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(11)]
	public string TermsTypeCode { get; set; }

	[Position(12)]
	public string MortgageInsurancePremiumTypeCode { get; set; }

	[Position(13)]
	public string Amount { get; set; }

	[Position(14)]
	public string PremiumSourceEntityCode { get; set; }

	[Position(15)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(16)]
	public string ProductServiceID { get; set; }

	[Position(17)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MIC_MortgageInsuranceCoverage>(this);
		validator.Required(x=>x.MortgageInsuranceApplicationType);
		validator.Length(x => x.MortgageInsuranceApplicationType, 1);
		validator.Length(x => x.MortgageInsuranceCoverageTypeCode, 1);
		validator.Length(x => x.MortgageInsuranceCertificateTypeCode, 1);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.PremiumRatePatternCode, 1);
		validator.Length(x => x.MortgageInsuranceDurationCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MortgageInsuranceRenewalOptionCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.TermsTypeCode, 2);
		validator.Length(x => x.MortgageInsurancePremiumTypeCode, 1);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.PremiumSourceEntityCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.ProductServiceID, 1, 48);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		return validator.Results;
	}
}
