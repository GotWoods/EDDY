using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("MES")]
public class MES_Measurements : EdifactSegment
{
	[Position(1)]
	public E175_MeasurementValueAndDetails MeasurementValueAndDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MES_Measurements>(this);
		validator.Required(x=>x.MeasurementValueAndDetails);
		return validator.Results;
	}
}
