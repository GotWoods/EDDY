using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C239")]
public class C239_TemperatureSetting : EdifactComponent
{
	[Position(1)]
	public string TemperatureValue { get; set; }

	[Position(2)]
	public string MeasurementUnitCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C239_TemperatureSetting>(this);
		validator.Length(x => x.TemperatureValue, 1, 15);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		return validator.Results;
	}
}
