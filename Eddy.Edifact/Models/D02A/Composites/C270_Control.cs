using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D02A.Composites;

[Segment("C270")]
public class C270_Control : EdifactComponent
{
	[Position(1)]
	public string ControlTotalTypeCodeQualifier { get; set; }

	[Position(2)]
	public string ControlTotalQuantity { get; set; }

	[Position(3)]
	public string MeasurementUnitCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C270_Control>(this);
		validator.Required(x=>x.ControlTotalTypeCodeQualifier);
		validator.Required(x=>x.ControlTotalQuantity);
		validator.Length(x => x.ControlTotalTypeCodeQualifier, 1, 3);
		validator.Length(x => x.ControlTotalQuantity, 1, 18);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		return validator.Results;
	}
}
