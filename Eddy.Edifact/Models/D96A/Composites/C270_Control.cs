using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C270")]
public class C270_Control : EdifactComponent
{
	[Position(1)]
	public string ControlQualifier { get; set; }

	[Position(2)]
	public string ControlValue { get; set; }

	[Position(3)]
	public string MeasureUnitQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C270_Control>(this);
		validator.Required(x=>x.ControlQualifier);
		validator.Required(x=>x.ControlValue);
		validator.Length(x => x.ControlQualifier, 1, 3);
		validator.Length(x => x.ControlValue, 1, 18);
		validator.Length(x => x.MeasureUnitQualifier, 1, 3);
		return validator.Results;
	}
}
