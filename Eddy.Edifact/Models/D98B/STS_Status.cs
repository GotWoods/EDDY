using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("STS")]
public class STS_Status : EdifactSegment
{
	[Position(1)]
	public C601_StatusCategory StatusCategory { get; set; }

	[Position(2)]
	public C555_Status Status { get; set; }

	[Position(3)]
	public C556_StatusReason StatusReason { get; set; }

	[Position(4)]
	public C556_StatusReason StatusReason2 { get; set; }

	[Position(5)]
	public C556_StatusReason StatusReason3 { get; set; }

	[Position(6)]
	public C556_StatusReason StatusReason4 { get; set; }

	[Position(7)]
	public C556_StatusReason StatusReason5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STS_Status>(this);
		return validator.Results;
	}
}
