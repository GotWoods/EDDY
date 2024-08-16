using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D02A.Composites;

[Segment("E013")]
public class E013_DateAndTimeInformation : EdifactComponent
{
	[Position(1)]
	public string DateOrTimeOrPeriodFunctionCodeQualifier { get; set; }

	[Position(2)]
	public string DateOrTimeOrPeriodText { get; set; }

	[Position(3)]
	public string DateOrTimeOrPeriodFormatCode { get; set; }

	[Position(4)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E013_DateAndTimeInformation>(this);
		validator.Required(x=>x.DateOrTimeOrPeriodFunctionCodeQualifier);
		validator.Required(x=>x.DateOrTimeOrPeriodText);
		validator.Length(x => x.DateOrTimeOrPeriodFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.DateOrTimeOrPeriodText, 1, 35);
		validator.Length(x => x.DateOrTimeOrPeriodFormatCode, 1, 3);
		validator.Length(x => x.FreeText, 1, 512);
		return validator.Results;
	}
}
