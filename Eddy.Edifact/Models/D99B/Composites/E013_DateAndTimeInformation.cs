using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E013")]
public class E013_DateAndTimeInformation : EdifactComponent
{
	[Position(1)]
	public string DateTimePeriodFunctionCodeQualifier { get; set; }

	[Position(2)]
	public string DateTimePeriodValue { get; set; }

	[Position(3)]
	public string DateTimePeriodFormatCode { get; set; }

	[Position(4)]
	public string FreeTextValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E013_DateAndTimeInformation>(this);
		validator.Required(x=>x.DateTimePeriodFunctionCodeQualifier);
		validator.Required(x=>x.DateTimePeriodValue);
		validator.Length(x => x.DateTimePeriodFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.DateTimePeriodValue, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatCode, 1, 3);
		validator.Length(x => x.FreeTextValue, 1, 512);
		return validator.Results;
	}
}
