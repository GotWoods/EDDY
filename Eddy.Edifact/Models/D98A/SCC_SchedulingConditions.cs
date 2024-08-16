using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Models.D98A;

[Segment("SCC")]
public class SCC_SchedulingConditions : EdifactSegment
{
	[Position(1)]
	public string DeliveryPlanCommitmentLevelCoded { get; set; }

	[Position(2)]
	public string DeliveryInstructionCoded { get; set; }

	[Position(3)]
	public C329_PatternDescription PatternDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCC_SchedulingConditions>(this);
		validator.Required(x=>x.DeliveryPlanCommitmentLevelCoded);
		validator.Length(x => x.DeliveryPlanCommitmentLevelCoded, 1, 3);
		validator.Length(x => x.DeliveryInstructionCoded, 1, 3);
		return validator.Results;
	}
}
