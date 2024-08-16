using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("QVR")]
public class QVR_QuantityVariances : EdifactSegment
{
	[Position(1)]
	public C279_QuantityDifferenceInformation QuantityDifferenceInformation { get; set; }

	[Position(2)]
	public string DiscrepancyCoded { get; set; }

	[Position(3)]
	public C960_ReasonForChange ReasonForChange { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<QVR_QuantityVariances>(this);
		validator.Length(x => x.DiscrepancyCoded, 1, 3);
		return validator.Results;
	}
}
