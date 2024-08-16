using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E964")]
public class E964_TravellerTimeDetails : EdifactComponent
{
	[Position(1)]
	public string TimeValue { get; set; }

	[Position(2)]
	public string TimeValue2 { get; set; }

	[Position(3)]
	public string CheckInDateOrTimeValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E964_TravellerTimeDetails>(this);
		validator.Length(x => x.TimeValue, 4);
		validator.Length(x => x.TimeValue2, 4);
		validator.Length(x => x.CheckInDateOrTimeValue, 1, 10);
		return validator.Results;
	}
}
