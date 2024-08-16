using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("SCC")]
public class SCC_SchedulingConditions : EdifactSegment
{
	[Position(1)]
	public string DeliveryPlanCommitmentLevelCode { get; set; }

	[Position(2)]
	public string DeliveryInstructionCoded { get; set; }

	[Position(3)]
	public C329_PatternDescription PatternDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCC_SchedulingConditions>(this);
		validator.Required(x=>x.DeliveryPlanCommitmentLevelCode);
		validator.Length(x => x.DeliveryPlanCommitmentLevelCode, 1, 3);
		validator.Length(x => x.DeliveryInstructionCoded, 1, 3);
		return validator.Results;
	}
}
