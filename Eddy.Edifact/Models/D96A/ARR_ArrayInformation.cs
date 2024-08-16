using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("ARR")]
public class ARR_ArrayInformation : EdifactSegment
{
	[Position(1)]
	public C778_PositionIdentification PositionIdentification { get; set; }

	[Position(2)]
	public C770_ArrayCellDetails ArrayCellDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ARR_ArrayInformation>(this);
		return validator.Results;
	}
}
