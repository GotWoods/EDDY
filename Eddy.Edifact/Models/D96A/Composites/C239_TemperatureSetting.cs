using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C239")]
public class C239_TemperatureSetting : EdifactComponent
{
	[Position(1)]
	public string TemperatureSetting { get; set; }

	[Position(2)]
	public string MeasureUnitQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C239_TemperatureSetting>(this);
		validator.Length(x => x.TemperatureSetting, 3);
		validator.Length(x => x.MeasureUnitQualifier, 1, 3);
		return validator.Results;
	}
}
