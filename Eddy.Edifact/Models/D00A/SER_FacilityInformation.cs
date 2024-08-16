using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("SER")]
public class SER_FacilityInformation : EdifactSegment
{
	[Position(1)]
	public E965_Facilities Facilities { get; set; }

	[Position(2)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	[Position(3)]
	public string UnitsQuantity { get; set; }

	[Position(4)]
	public E013_DateAndTimeInformation DateAndTimeInformation { get; set; }

	[Position(5)]
	public string DaysOfWeekSetIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SER_FacilityInformation>(this);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		validator.Length(x => x.UnitsQuantity, 1, 15);
		validator.Length(x => x.DaysOfWeekSetIdentifier, 1, 7);
		return validator.Results;
	}
}
