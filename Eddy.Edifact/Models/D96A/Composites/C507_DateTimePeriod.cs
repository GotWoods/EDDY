using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C507")]
public class C507_DateTimePeriod : EdifactComponent
{
	[Position(1)]
	public string DateTimePeriodQualifier { get; set; }

	[Position(2)]
	public string DateTimePeriod { get; set; }

	[Position(3)]
	public string DateTimePeriodFormatQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C507_DateTimePeriod>(this);
		validator.Required(x=>x.DateTimePeriodQualifier);
		validator.Length(x => x.DateTimePeriodQualifier, 1, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 1, 3);
		return validator.Results;
	}
}
