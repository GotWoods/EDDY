using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("ADI")]
public class ADI_HealthCareClaimAdjudicationInformation : EdifactSegment
{
	[Position(1)]
	public E206_ObjectIdentification ObjectIdentification { get; set; }

	[Position(2)]
	public E021_Service Service { get; set; }

	[Position(3)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	[Position(4)]
	public E017_MonetaryAmount MonetaryAmount { get; set; }

	[Position(5)]
	public string Quantity { get; set; }

	[Position(6)]
	public E030_AdjustmentInformation AdjustmentInformation { get; set; }

	[Position(7)]
	public string PolicyLimitationIdentifier { get; set; }

	[Position(8)]
	public string ProductGroupNameCode { get; set; }

	[Position(9)]
	public E507_DateTimePeriod DateTimePeriod { get; set; }

	[Position(10)]
	public string DiagnosisCategoryCode { get; set; }

	[Position(11)]
	public string Percentage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ADI_HealthCareClaimAdjudicationInformation>(this);
		validator.Required(x=>x.ObjectIdentification);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.PolicyLimitationIdentifier, 1, 10);
		validator.Length(x => x.ProductGroupNameCode, 1, 25);
		validator.Length(x => x.DiagnosisCategoryCode, 1, 3);
		validator.Length(x => x.Percentage, 1, 10);
		return validator.Results;
	}
}
