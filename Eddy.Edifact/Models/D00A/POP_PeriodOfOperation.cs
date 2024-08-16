using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("POP")]
public class POP_PeriodOfOperation : EdifactSegment
{
	[Position(1)]
	public E013_DateAndTimeInformation DateAndTimeInformation { get; set; }

	[Position(2)]
	public string DaysOfWeekSetIdentifier { get; set; }

	[Position(3)]
	public string StatusDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<POP_PeriodOfOperation>(this);
		validator.Required(x=>x.DateAndTimeInformation);
		validator.Length(x => x.DaysOfWeekSetIdentifier, 1, 7);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		return validator.Results;
	}
}
