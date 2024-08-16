using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E964")]
public class E964_TravellerTimeDetails : EdifactComponent
{
	[Position(1)]
	public string Time { get; set; }

	[Position(2)]
	public string Time2 { get; set; }

	[Position(3)]
	public string CheckInTime { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E964_TravellerTimeDetails>(this);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.Time2, 4);
		validator.Length(x => x.CheckInTime, 1, 10);
		return validator.Results;
	}
}
