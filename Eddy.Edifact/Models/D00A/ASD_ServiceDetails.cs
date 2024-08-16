using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("ASD")]
public class ASD_ServiceDetails : EdifactSegment
{
	[Position(1)]
	public E959_ServiceDateTimeLocationInformation ServiceDateTimeLocationInformation { get; set; }

	[Position(2)]
	public E013_DateAndTimeInformation DateAndTimeInformation { get; set; }

	[Position(3)]
	public string DaysOfWeekSetIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ASD_ServiceDetails>(this);
		validator.Required(x=>x.ServiceDateTimeLocationInformation);
		validator.Length(x => x.DaysOfWeekSetIdentifier, 1, 7);
		return validator.Results;
	}
}
