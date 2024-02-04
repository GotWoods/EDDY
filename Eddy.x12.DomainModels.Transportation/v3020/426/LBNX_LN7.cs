using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._426;

public class LBNX_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(3)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(4)] public M12_InBondIdentifyingInformation? InBondIdentifyingInformation { get; set; }
	[SectionPosition(5)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(6)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBNX_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 21);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		return validator.Results;
	}
}
