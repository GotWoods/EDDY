using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E009")]
public class E009_DailyAvailabilityInformation : EdifactComponent
{
	[Position(1)]
	public string Date { get; set; }

	[Position(2)]
	public string RequestedInformationDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E009_DailyAvailabilityInformation>(this);
		validator.Required(x=>x.Date);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.RequestedInformationDescription, 1, 35);
		return validator.Results;
	}
}
