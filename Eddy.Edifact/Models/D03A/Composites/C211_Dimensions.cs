using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D03A.Composites;

[Segment("C211")]
public class C211_Dimensions : EdifactComponent
{
	[Position(1)]
	public string MeasurementUnitCode { get; set; }

	[Position(2)]
	public string LengthMeasure { get; set; }

	[Position(3)]
	public string WidthMeasure { get; set; }

	[Position(4)]
	public string HeightMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C211_Dimensions>(this);
		validator.Required(x=>x.MeasurementUnitCode);
		validator.Length(x => x.MeasurementUnitCode, 1, 8);
		validator.Length(x => x.LengthMeasure, 1, 15);
		validator.Length(x => x.WidthMeasure, 1, 15);
		validator.Length(x => x.HeightMeasure, 1, 15);
		return validator.Results;
	}
}
