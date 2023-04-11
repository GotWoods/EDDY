using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CQ")]
public class CQ_CredentialsAndQualifications : EdiX12Segment
{
	[Position(01)]
	public string CredentialTypeCode { get; set; }

	[Position(02)]
	public string CredentialCategoryCode { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	[Position(05)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(06)]
	public string BasisForAcademicCreditOrAwardOfCredentialCode { get; set; }

	[Position(07)]
	public string CredentialRequirementCode { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string ConditionIndicatorCode { get; set; }

	[Position(10)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CQ_CredentialsAndQualifications>(this);
		validator.Required(x=>x.CredentialTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.CredentialTypeCode, 1, 2);
		validator.Length(x => x.CredentialCategoryCode, 1, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.BasisForAcademicCreditOrAwardOfCredentialCode, 1);
		validator.Length(x => x.CredentialRequirementCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}
