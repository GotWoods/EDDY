using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C280")]
public class C280_Range : EdifactComponent
{
	[Position(1)]
	public string MeasureUnitQualifier { get; set; }

	[Position(2)]
	public string RangeMinimum { get; set; }

	[Position(3)]
	public string RangeMaximum { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C280_Range>(this);
		validator.Required(x=>x.MeasureUnitQualifier);
		validator.Length(x => x.MeasureUnitQualifier, 1, 3);
		validator.Length(x => x.RangeMinimum, 1, 18);
		validator.Length(x => x.RangeMaximum, 1, 18);
		return validator.Results;
	}
}
