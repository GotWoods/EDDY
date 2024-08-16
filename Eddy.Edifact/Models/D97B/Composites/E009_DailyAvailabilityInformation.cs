using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97B.Composites;

[Segment("E009")]
public class E009_DailyAvailabilityInformation : EdifactComponent
{
	[Position(1)]
	public string Date { get; set; }

	[Position(2)]
	public string RequestedInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E009_DailyAvailabilityInformation>(this);
		validator.Required(x=>x.Date);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.RequestedInformation, 1, 35);
		return validator.Results;
	}
}
