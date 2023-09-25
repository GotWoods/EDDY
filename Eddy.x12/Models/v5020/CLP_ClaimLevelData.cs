using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5020;

[Segment("CLP")]
public class CLP_ClaimLevelData : EdiX12Segment
{
	[Position(01)]
	public string ClaimSubmittersIdentifier { get; set; }

	[Position(02)]
	public string ClaimStatusCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(06)]
	public string ClaimFilingIndicatorCode { get; set; }

	[Position(07)]
	public string ReferenceIdentification { get; set; }

	[Position(08)]
	public string FacilityCodeValue { get; set; }

	[Position(09)]
	public string ClaimFrequencyTypeCode { get; set; }

	[Position(10)]
	public string PatientStatusCode { get; set; }

	[Position(11)]
	public string DiagnosisRelatedGroupDRGCode { get; set; }

	[Position(12)]
	public decimal? Quantity { get; set; }

	[Position(13)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(14)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(15)]
	public decimal? ExchangeRate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLP_ClaimLevelData>(this);
		validator.Required(x=>x.ClaimSubmittersIdentifier);
		validator.Required(x=>x.ClaimStatusCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.MonetaryAmount2);
		validator.Length(x => x.ClaimSubmittersIdentifier, 1, 38);
		validator.Length(x => x.ClaimStatusCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.ClaimFilingIndicatorCode, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.FacilityCodeValue, 1, 2);
		validator.Length(x => x.ClaimFrequencyTypeCode, 1);
		validator.Length(x => x.PatientStatusCode, 1, 2);
		validator.Length(x => x.DiagnosisRelatedGroupDRGCode, 1, 4);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ExchangeRate, 4, 10);
		return validator.Results;
	}
}
