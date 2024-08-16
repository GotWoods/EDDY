using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Models.D02A;

[Segment("TCE")]
public class TCE_TimeAndCertainty : EdifactSegment
{
	[Position(1)]
	public string DateOrTimeOrPeriodText { get; set; }

	[Position(2)]
	public E946_Certainty Certainty { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TCE_TimeAndCertainty>(this);
		validator.Length(x => x.DateOrTimeOrPeriodText, 1, 35);
		return validator.Results;
	}
}
