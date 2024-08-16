using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10A.Composites;

namespace Eddy.Edifact.Models.D10A;

[Segment("GDS")]
public class GDS_NatureOfCargo : EdifactSegment
{
	[Position(1)]
	public C703_NatureOfCargo NatureOfCargo { get; set; }

	[Position(2)]
	public C288_ProductGroup ProductGroup { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GDS_NatureOfCargo>(this);
		return validator.Results;
	}
}
