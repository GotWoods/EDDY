using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Models.D06A;

[Segment("INP")]
public class INP_PartiesAndInstruction : EdifactSegment
{
	[Position(1)]
	public C849_PartiesToInstruction PartiesToInstruction { get; set; }

	[Position(2)]
	public C522_Instruction Instruction { get; set; }

	[Position(3)]
	public C850_StatusOfInstruction StatusOfInstruction { get; set; }

	[Position(4)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INP_PartiesAndInstruction>(this);
		validator.Length(x => x.ActionCode, 1, 3);
		return validator.Results;
	}
}
