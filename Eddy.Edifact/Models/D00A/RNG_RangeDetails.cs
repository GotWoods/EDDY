using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("RNG")]
public class RNG_RangeDetails : EdifactSegment
{
	[Position(1)]
	public string RangeTypeCodeQualifier { get; set; }

	[Position(2)]
	public C280_Range Range { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RNG_RangeDetails>(this);
		validator.Required(x=>x.RangeTypeCodeQualifier);
		validator.Length(x => x.RangeTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
