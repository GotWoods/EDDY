using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("OTI")]
public class OTI_OtherInsurance : EdifactSegment
{
	[Position(1)]
	public E206_ObjectIdentification ObjectIdentification { get; set; }

	[Position(2)]
	public string PayerResponsibilityLevelCode { get; set; }

	[Position(3)]
	public E507_DateTimePeriod DateTimePeriod { get; set; }

	[Position(4)]
	public string ServiceTypeCode { get; set; }

	[Position(5)]
	public string MonetaryAmount { get; set; }

	[Position(6)]
	public E030_AdjustmentInformation AdjustmentInformation { get; set; }

	[Position(7)]
	public string InsuranceCoverTypeCode { get; set; }

	[Position(8)]
	public string RelationshipDescriptionCode { get; set; }

	[Position(9)]
	public string YesOrNoIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OTI_OtherInsurance>(this);
		validator.Required(x=>x.ObjectIdentification);
		validator.Required(x=>x.PayerResponsibilityLevelCode);
		validator.Length(x => x.PayerResponsibilityLevelCode, 1, 3);
		validator.Length(x => x.ServiceTypeCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.InsuranceCoverTypeCode, 1, 3);
		validator.Length(x => x.RelationshipDescriptionCode, 1, 3);
		validator.Length(x => x.YesOrNoIndicatorCode, 1, 3);
		return validator.Results;
	}
}
