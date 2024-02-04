using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._858;

public class LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EM_EquipmentCharacteristics? EquipmentCharacteristics { get; set; }
	[SectionPosition(3)] public List<NA_CrossReferenceEquipment> CrossReferenceEquipment { get; set; } = new();
	[SectionPosition(4)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(5)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(7)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(8)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(9)] public E1_EmptyCarDispositionPendedDestinationConsignee? EmptyCarDispositionPendedDestinationConsignee { get; set; }
	[SectionPosition(10)] public E4_EmptyCarDispositionPendedDestinationCity? EmptyCarDispositionPendedDestinationCity { get; set; }
	[SectionPosition(11)] public List<E5_EmptyCarDispositionPendedDestinationRoute> EmptyCarDispositionPendedDestinationRoute { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.CrossReferenceEquipment, 0, 30);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 5);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 21);
		validator.CollectionSize(x => x.EmptyCarDispositionPendedDestinationRoute, 0, 13);
		return validator.Results;
	}
}
