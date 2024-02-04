using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._417;

public class LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EM_EquipmentCharacteristics? EquipmentCharacteristics { get; set; }
	[SectionPosition(3)] public List<LN7_LVC> LVC {get;set;} = new();
	[SectionPosition(4)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(5)] public IM_IntermodalMovementInformation? IntermodalMovementInformation { get; set; }
	[SectionPosition(6)] public M12_InBondIdentifyingInformation? InBondIdentifyingInformation { get; set; }
	[SectionPosition(7)] public G4_ScaleIdentification? ScaleIdentification { get; set; }
	[SectionPosition(8)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(9)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	[SectionPosition(10)] public H5_CarServiceOrder? CarServiceOrder { get; set; }
	[SectionPosition(11)] public E1_EmptyCarDispositionPendedDestinationConsignee? EmptyCarDispositionPendedDestinationConsignee { get; set; }
	[SectionPosition(12)] public E4_EmptyCarDispositionPendedDestinationCity? EmptyCarDispositionPendedDestinationCity { get; set; }
	[SectionPosition(13)] public List<E5_EmptyCarDispositionPendedDestinationRoute> EmptyCarDispositionPendedDestinationRoute { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.EmptyCarDispositionPendedDestinationRoute, 0, 13);
		validator.CollectionSize(x => x.LVC, 0, 21);
		foreach (var item in LVC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
