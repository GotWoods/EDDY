using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("DIM")]
public class DIM_Dimensions : EdifactSegment
{
	[Position(1)]
	public string DimensionQualifier { get; set; }

	[Position(2)]
	public C211_Dimensions Dimensions { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DIM_Dimensions>(this);
		validator.Required(x=>x.DimensionQualifier);
		validator.Required(x=>x.Dimensions);
		validator.Length(x => x.DimensionQualifier, 1, 3);
		return validator.Results;
	}
}
