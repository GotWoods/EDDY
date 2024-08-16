using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("INV")]
public class INV_InventoryManagementRelatedDetails : EdifactSegment
{
	[Position(1)]
	public string InventoryMovementDirectionCode { get; set; }

	[Position(2)]
	public string InventoryTypeCode { get; set; }

	[Position(3)]
	public string InventoryMovementReasonCode { get; set; }

	[Position(4)]
	public string InventoryBalanceMethodCode { get; set; }

	[Position(5)]
	public C522_Instruction Instruction { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INV_InventoryManagementRelatedDetails>(this);
		validator.Length(x => x.InventoryMovementDirectionCode, 1, 3);
		validator.Length(x => x.InventoryTypeCode, 1, 3);
		validator.Length(x => x.InventoryMovementReasonCode, 1, 3);
		validator.Length(x => x.InventoryBalanceMethodCode, 1, 3);
		return validator.Results;
	}
}
