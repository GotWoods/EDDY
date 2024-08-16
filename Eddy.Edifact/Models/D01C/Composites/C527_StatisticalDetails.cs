using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("C527")]
public class C527_StatisticalDetails : EdifactComponent
{
	[Position(1)]
	public string Measure { get; set; }

	[Position(2)]
	public string MeasurementUnitCode { get; set; }

	[Position(3)]
	public string MeasuredAttributeCode { get; set; }

	[Position(4)]
	public string MeasurementSignificanceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C527_StatisticalDetails>(this);
		validator.Length(x => x.Measure, 1, 18);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		validator.Length(x => x.MeasuredAttributeCode, 1, 3);
		validator.Length(x => x.MeasurementSignificanceCode, 1, 3);
		return validator.Results;
	}
}
