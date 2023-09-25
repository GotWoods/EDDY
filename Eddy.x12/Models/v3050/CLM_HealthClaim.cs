using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CLM")]
public class CLM_HealthClaim : EdiX12Segment
{
	[Position(01)]
	public string ClaimSubmittersIdentifier { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string ClaimFilingIndicatorCode { get; set; }

	[Position(04)]
	public string NonInstitutionalClaimTypeCode { get; set; }

	[Position(05)]
	public C023_HealthCareServiceLocationInformation HealthCareServiceLocationInformation { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string ProviderAcceptAssignmentCode { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(09)]
	public string ReleaseOfInformationCode { get; set; }

	[Position(10)]
	public string PatientSignatureSourceCode { get; set; }

	[Position(11)]
	public C024_RelatedCausesInformation RelatedCausesInformation { get; set; }

	[Position(12)]
	public string SpecialProgramCode { get; set; }

	[Position(13)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(14)]
	public string LevelOfServiceCode { get; set; }

	[Position(15)]
	public string YesNoConditionOrResponseCode4 { get; set; }

	[Position(16)]
	public string ProviderAgreementCode { get; set; }

	[Position(17)]
	public string ClaimStatusCode { get; set; }

	[Position(18)]
	public string YesNoConditionOrResponseCode5 { get; set; }

	[Position(19)]
	public string ClaimSubmissionReasonCode { get; set; }

	[Position(20)]
	public string DelayReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLM_HealthClaim>(this);
		validator.Required(x=>x.ClaimSubmittersIdentifier);
		validator.Length(x => x.ClaimSubmittersIdentifier, 1, 38);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.ClaimFilingIndicatorCode, 1, 2);
		validator.Length(x => x.NonInstitutionalClaimTypeCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ProviderAcceptAssignmentCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.ReleaseOfInformationCode, 1);
		validator.Length(x => x.PatientSignatureSourceCode, 1);
		validator.Length(x => x.SpecialProgramCode, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.LevelOfServiceCode, 1, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.ProviderAgreementCode, 1);
		validator.Length(x => x.ClaimStatusCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode5, 1);
		validator.Length(x => x.ClaimSubmissionReasonCode, 2);
		validator.Length(x => x.DelayReasonCode, 1, 2);
		return validator.Results;
	}
}
