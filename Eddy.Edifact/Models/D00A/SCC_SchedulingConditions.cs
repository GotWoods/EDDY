using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("SCC")]
public class SCC_SchedulingConditions : EdifactSegment
{
	[Position(1)]
	public string DeliveryPlanCommitmentLevelCode { get; set; }

	[Position(2)]
	public string DeliveryInstructionCode { get; set; }

	[Position(3)]
	public C329_PatternDescription PatternDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCC_SchedulingConditions>(this);
		validator.Required(x=>x.DeliveryPlanCommitmentLevelCode);
		validator.Length(x => x.DeliveryPlanCommitmentLevelCode, 1, 3);
		validator.Length(x => x.DeliveryInstructionCode, 1, 3);
		return validator.Results;
	}
}
