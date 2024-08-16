using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("AJT")]
public class AJT_AdjustmentDetails : EdifactSegment
{
	[Position(1)]
	public string AdjustmentReasonCoded { get; set; }

	[Position(2)]
	public string LineItemNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AJT_AdjustmentDetails>(this);
		validator.Required(x=>x.AdjustmentReasonCoded);
		validator.Length(x => x.AdjustmentReasonCoded, 1, 3);
		validator.Length(x => x.LineItemNumber, 1, 6);
		return validator.Results;
	}
}
