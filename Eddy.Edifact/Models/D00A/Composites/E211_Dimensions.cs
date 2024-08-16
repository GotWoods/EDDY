using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E211")]
public class E211_Dimensions : EdifactComponent
{
	[Position(1)]
	public string MeasurementUnitCode { get; set; }

	[Position(2)]
	public string LengthDimensionValue { get; set; }

	[Position(3)]
	public string WidthDimensionValue { get; set; }

	[Position(4)]
	public string HeightDimensionValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E211_Dimensions>(this);
		validator.Required(x=>x.MeasurementUnitCode);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		validator.Length(x => x.LengthDimensionValue, 1, 15);
		validator.Length(x => x.WidthDimensionValue, 1, 15);
		validator.Length(x => x.HeightDimensionValue, 1, 15);
		return validator.Results;
	}
}
