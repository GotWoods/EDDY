using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E963")]
public class E963_DistanceOrTimeDetails : EdifactComponent
{
	[Position(1)]
	public string Measure { get; set; }

	[Position(2)]
	public string MeasurementUnitCode { get; set; }

	[Position(3)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E963_DistanceOrTimeDetails>(this);
		validator.Length(x => x.Measure, 1, 18);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		validator.Length(x => x.Time, 4);
		return validator.Results;
	}
}