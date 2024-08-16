using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D03A.Composites;

[Segment("C174")]
public class C174_ValueRange : EdifactComponent
{
	[Position(1)]
	public string MeasurementUnitCode { get; set; }

	[Position(2)]
	public string Measure { get; set; }

	[Position(3)]
	public string RangeMinimumQuantity { get; set; }

	[Position(4)]
	public string RangeMaximumQuantity { get; set; }

	[Position(5)]
	public string SignificantDigitsQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C174_ValueRange>(this);
		validator.Required(x=>x.MeasurementUnitCode);
		validator.Length(x => x.MeasurementUnitCode, 1, 8);
		validator.Length(x => x.Measure, 1, 18);
		validator.Length(x => x.RangeMinimumQuantity, 1, 18);
		validator.Length(x => x.RangeMaximumQuantity, 1, 18);
		validator.Length(x => x.SignificantDigitsQuantity, 1, 2);
		return validator.Results;
	}
}
