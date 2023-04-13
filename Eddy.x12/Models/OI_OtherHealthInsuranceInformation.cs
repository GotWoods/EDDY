using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("OI")]
public class OI_OtherHealthInsuranceInformation : EdiX12Segment
{
	[Position(01)]
	public string ClaimFilingIndicatorCode { get; set; }

	[Position(02)]
	public string ClaimSubmissionReasonCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(04)]
	public string PatientSignatureSourceCode { get; set; }

	[Position(05)]
	public string ProviderAgreementCode { get; set; }

	[Position(06)]
	public string ReleaseOfInformationCode { get; set; }

	[Position(07)]
	public string ProviderAcceptAssignmentCode { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode4 { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OI_OtherHealthInsuranceInformation>(this);
		validator.Length(x => x.ClaimFilingIndicatorCode, 1, 2);
		validator.Length(x => x.ClaimSubmissionReasonCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.PatientSignatureSourceCode, 1);
		validator.Length(x => x.ProviderAgreementCode, 1);
		validator.Length(x => x.ReleaseOfInformationCode, 1);
		validator.Length(x => x.ProviderAcceptAssignmentCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode5, 1);
		return validator.Results;
	}
}
