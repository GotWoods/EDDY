using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._214;

public class L0200__L0230__L0233_L0240 {
	[SectionPosition(1)] public AT7_ShipmentStatusDetails ShipmentStatusDetails { get; set; } = new();
	[SectionPosition(2)] public MS1_EquipmentShipmentOrRealPropertyLocation? EquipmentShipmentOrRealPropertyLocation { get; set; }
	[SectionPosition(3)] public MS2_EquipmentOrContainerOwnerAndType? EquipmentOrContainerOwnerAndType { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0230__L0233_L0240>(this);
		validator.Required(x => x.ShipmentStatusDetails);
		return validator.Results;
	}
}
