using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("DAV")]
public class DAV_DailyAvailability : EdifactSegment
{
	[Position(1)]
	public string CharacteristicDescriptionCode { get; set; }

	[Position(2)]
	public E009_DailyAvailabilityInformation DailyAvailabilityInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DAV_DailyAvailability>(this);
		validator.Required(x=>x.CharacteristicDescriptionCode);
		validator.Required(x=>x.DailyAvailabilityInformation);
		validator.Length(x => x.CharacteristicDescriptionCode, 1, 17);
		return validator.Results;
	}
}
