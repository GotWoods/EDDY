using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("DAV")]
public class DAV_DailyAvailability : EdifactSegment
{
	[Position(1)]
	public string CharacteristicIdentification { get; set; }

	[Position(2)]
	public E009_DailyAvailabilityInformation DailyAvailabilityInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DAV_DailyAvailability>(this);
		validator.Required(x=>x.CharacteristicIdentification);
		validator.Required(x=>x.DailyAvailabilityInformation);
		validator.Length(x => x.CharacteristicIdentification, 1, 17);
		return validator.Results;
	}
}
