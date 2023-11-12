using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5050;

[Segment("SBR")]
public class SBR_SubscriberInformation : EdiX12Segment
{
	[Position(01)]
	public string PayerResponsibilitySequenceNumberCode { get; set; }

	[Position(02)]
	public string IndividualRelationshipCode { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string Name { get; set; }

	[Position(05)]
	public string InsuranceTypeCode { get; set; }

	[Position(06)]
	public string CoordinationOfBenefitsCode { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(08)]
	public string EmploymentStatusCode { get; set; }

	[Position(09)]
	public string ClaimFilingIndicatorCode { get; set; }

	[Position(10)]
	public string SourceOfPaymentTypologyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SBR_SubscriberInformation>(this);
		validator.Required(x=>x.PayerResponsibilitySequenceNumberCode);
		validator.Length(x => x.PayerResponsibilitySequenceNumberCode, 1);
		validator.Length(x => x.IndividualRelationshipCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.InsuranceTypeCode, 1, 3);
		validator.Length(x => x.CoordinationOfBenefitsCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.ClaimFilingIndicatorCode, 1, 2);
		validator.Length(x => x.SourceOfPaymentTypologyCode, 2, 6);
		return validator.Results;
	}
}
