using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S300")]
public class S300_DateAndOrTimeOfInitiation : EdifactComponent
{
	[Position(1)]
	public string EventDate { get; set; }

	[Position(2)]
	public string EventTime { get; set; }

	[Position(3)]
	public string TimeOffset { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S300_DateAndOrTimeOfInitiation>(this);
		validator.Length(x => x.EventDate, 1, 8);
		validator.Length(x => x.EventTime, 1, 15);
		validator.Length(x => x.TimeOffset, 4);
		return validator.Results;
	}
}
