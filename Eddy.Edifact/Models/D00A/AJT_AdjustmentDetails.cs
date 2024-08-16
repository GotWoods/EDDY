using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("AJT")]
public class AJT_AdjustmentDetails : EdifactSegment
{
	[Position(1)]
	public string AdjustmentReasonDescriptionCode { get; set; }

	[Position(2)]
	public string LineItemIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AJT_AdjustmentDetails>(this);
		validator.Required(x=>x.AdjustmentReasonDescriptionCode);
		validator.Length(x => x.AdjustmentReasonDescriptionCode, 1, 3);
		validator.Length(x => x.LineItemIdentifier, 1, 6);
		return validator.Results;
	}
}
