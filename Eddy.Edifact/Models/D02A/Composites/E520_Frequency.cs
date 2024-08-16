using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D02A.Composites;

[Segment("E520")]
public class E520_Frequency : EdifactComponent
{
	[Position(1)]
	public string FrequencyRate { get; set; }

	[Position(2)]
	public string MeasurementUnitCode { get; set; }

	[Position(3)]
	public string DateOrTimeOrPeriodText { get; set; }

	[Position(4)]
	public string DateOrTimeOrPeriodFormatCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E520_Frequency>(this);
		validator.Required(x=>x.FrequencyRate);
		validator.Length(x => x.FrequencyRate, 1, 9);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		validator.Length(x => x.DateOrTimeOrPeriodText, 1, 35);
		validator.Length(x => x.DateOrTimeOrPeriodFormatCode, 1, 3);
		return validator.Results;
	}
}
