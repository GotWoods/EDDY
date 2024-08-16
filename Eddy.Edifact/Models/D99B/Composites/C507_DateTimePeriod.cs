using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C507")]
public class C507_DateTimePeriod : EdifactComponent
{
	[Position(1)]
	public string DateTimePeriodFunctionCodeQualifier { get; set; }

	[Position(2)]
	public string DateTimePeriodValue { get; set; }

	[Position(3)]
	public string DateTimePeriodFormatCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C507_DateTimePeriod>(this);
		validator.Required(x=>x.DateTimePeriodFunctionCodeQualifier);
		validator.Length(x => x.DateTimePeriodFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.DateTimePeriodValue, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatCode, 1, 3);
		return validator.Results;
	}
}
