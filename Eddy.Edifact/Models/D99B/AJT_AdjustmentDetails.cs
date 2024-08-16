using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("AJT")]
public class AJT_AdjustmentDetails : EdifactSegment
{
	[Position(1)]
	public string AdjustmentReasonDescriptionCode { get; set; }

	[Position(2)]
	public string LineItemNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AJT_AdjustmentDetails>(this);
		validator.Required(x=>x.AdjustmentReasonDescriptionCode);
		validator.Length(x => x.AdjustmentReasonDescriptionCode, 1, 3);
		validator.Length(x => x.LineItemNumber, 1, 6);
		return validator.Results;
	}
}
