using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("INV")]
public class INV_InventoryManagementRelatedDetails : EdifactSegment
{
	[Position(1)]
	public string InventoryMovementDirectionCoded { get; set; }

	[Position(2)]
	public string TypeOfInventoryAffectedCoded { get; set; }

	[Position(3)]
	public string ReasonForInventoryMovementCoded { get; set; }

	[Position(4)]
	public string InventoryBalanceMethodCoded { get; set; }

	[Position(5)]
	public C522_Instruction Instruction { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INV_InventoryManagementRelatedDetails>(this);
		validator.Length(x => x.InventoryMovementDirectionCoded, 1, 3);
		validator.Length(x => x.TypeOfInventoryAffectedCoded, 1, 3);
		validator.Length(x => x.ReasonForInventoryMovementCoded, 1, 3);
		validator.Length(x => x.InventoryBalanceMethodCoded, 1, 3);
		return validator.Results;
	}
}
