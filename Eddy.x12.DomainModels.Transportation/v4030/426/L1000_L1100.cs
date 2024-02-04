using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._426;

public class L1000_L1100 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(3)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(4)] public G4_ScaleIdentification? ScaleIdentification { get; set; }
	[SectionPosition(5)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(6)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	[SectionPosition(7)] public List<GA_CanadianGrainInformation> CanadianGrainInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000_L1100>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 30);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.CanadianGrainInformation, 0, 15);
		return validator.Results;
	}
}
