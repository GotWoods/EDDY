using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("TMP")]
public class TMP_Temperature : EdifactSegment
{
	[Position(1)]
	public string TemperatureQualifier { get; set; }

	[Position(2)]
	public C239_TemperatureSetting TemperatureSetting { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TMP_Temperature>(this);
		validator.Required(x=>x.TemperatureQualifier);
		validator.Length(x => x.TemperatureQualifier, 1, 3);
		return validator.Results;
	}
}
