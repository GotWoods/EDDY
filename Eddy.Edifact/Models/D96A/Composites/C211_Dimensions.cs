using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C211")]
public class C211_Dimensions : EdifactComponent
{
	[Position(1)]
	public string MeasureUnitQualifier { get; set; }

	[Position(2)]
	public string LengthDimension { get; set; }

	[Position(3)]
	public string WidthDimension { get; set; }

	[Position(4)]
	public string HeightDimension { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C211_Dimensions>(this);
		validator.Required(x=>x.MeasureUnitQualifier);
		validator.Length(x => x.MeasureUnitQualifier, 1, 3);
		validator.Length(x => x.LengthDimension, 1, 15);
		validator.Length(x => x.WidthDimension, 1, 15);
		validator.Length(x => x.HeightDimension, 1, 15);
		return validator.Results;
	}
}
