using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("DIM")]
public class DIM_Dimensions : EdifactSegment
{
	[Position(1)]
	public string DimensionTypeCodeQualifier { get; set; }

	[Position(2)]
	public C211_Dimensions Dimensions { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DIM_Dimensions>(this);
		validator.Required(x=>x.DimensionTypeCodeQualifier);
		validator.Required(x=>x.Dimensions);
		validator.Length(x => x.DimensionTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
