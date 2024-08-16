using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

[Segment("E013")]
public class E013_DateAndTimeInformation : EdifactComponent
{
	[Position(1)]
	public string DateTimePeriodQualifier { get; set; }

	[Position(2)]
	public string DateTimePeriod { get; set; }

	[Position(3)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(4)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E013_DateAndTimeInformation>(this);
		validator.Required(x=>x.DateTimePeriodQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.Length(x => x.DateTimePeriodQualifier, 1, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 1, 3);
		validator.Length(x => x.FreeText, 1, 70);
		return validator.Results;
	}
}
