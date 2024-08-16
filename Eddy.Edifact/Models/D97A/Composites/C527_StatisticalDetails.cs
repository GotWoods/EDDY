using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("C527")]
public class C527_StatisticalDetails : EdifactComponent
{
	[Position(1)]
	public string MeasurementValue { get; set; }

	[Position(2)]
	public string MeasureUnitQualifier { get; set; }

	[Position(3)]
	public string PropertyMeasuredCoded { get; set; }

	[Position(4)]
	public string MeasurementSignificanceCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C527_StatisticalDetails>(this);
		validator.Length(x => x.MeasurementValue, 1, 18);
		validator.Length(x => x.MeasureUnitQualifier, 1, 3);
		validator.Length(x => x.PropertyMeasuredCoded, 1, 3);
		validator.Length(x => x.MeasurementSignificanceCoded, 1, 3);
		return validator.Results;
	}
}
