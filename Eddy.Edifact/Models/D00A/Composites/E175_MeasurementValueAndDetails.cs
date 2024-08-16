using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E175")]
public class E175_MeasurementValueAndDetails : EdifactComponent
{
	[Position(1)]
	public string MeasurementValue { get; set; }

	[Position(2)]
	public string MeasurementUnitCode { get; set; }

	[Position(3)]
	public string MeasuredAttributeCode { get; set; }

	[Position(4)]
	public string MeasurementSignificanceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E175_MeasurementValueAndDetails>(this);
		validator.Required(x=>x.MeasurementValue);
		validator.Length(x => x.MeasurementValue, 1, 18);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		validator.Length(x => x.MeasuredAttributeCode, 1, 3);
		validator.Length(x => x.MeasurementSignificanceCode, 1, 3);
		return validator.Results;
	}
}