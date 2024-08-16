using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C280")]
public class C280_Range : EdifactComponent
{
	[Position(1)]
	public string MeasurementUnitCode { get; set; }

	[Position(2)]
	public string RangeMinimumValue { get; set; }

	[Position(3)]
	public string RangeMaximumValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C280_Range>(this);
		validator.Required(x=>x.MeasurementUnitCode);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		validator.Length(x => x.RangeMinimumValue, 1, 18);
		validator.Length(x => x.RangeMaximumValue, 1, 18);
		return validator.Results;
	}
}
