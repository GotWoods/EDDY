using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S501")]
public class S501_SecurityDateAndTime : EdifactComponent
{
	[Position(1)]
	public string DateAndTimeQualifier { get; set; }

	[Position(2)]
	public string EventDate { get; set; }

	[Position(3)]
	public string EventTime { get; set; }

	[Position(4)]
	public string TimeOffset { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S501_SecurityDateAndTime>(this);
		validator.Required(x=>x.DateAndTimeQualifier);
		validator.Length(x => x.DateAndTimeQualifier, 1, 3);
		validator.Length(x => x.EventDate, 1, 8);
		validator.Length(x => x.EventTime, 1, 15);
		validator.Length(x => x.TimeOffset, 4);
		return validator.Results;
	}
}
