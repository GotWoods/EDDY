using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E507")]
public class E507_DateTimePeriod : EdifactComponent
{
	[Position(1)]
	public string DateOrTimeOrPeriodFunctionCodeQualifier { get; set; }

	[Position(2)]
	public string DateOrTimeOrPeriodValue { get; set; }

	[Position(3)]
	public string DateOrTimeOrPeriodFormatCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E507_DateTimePeriod>(this);
		validator.Required(x=>x.DateOrTimeOrPeriodFunctionCodeQualifier);
		validator.Length(x => x.DateOrTimeOrPeriodFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.DateOrTimeOrPeriodValue, 1, 35);
		validator.Length(x => x.DateOrTimeOrPeriodFormatCode, 1, 3);
		return validator.Results;
	}
}
