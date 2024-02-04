using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._417;

public class LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EM_EquipmentCharacteristics? EquipmentCharacteristics { get; set; }
	[SectionPosition(3)] public List<LN7_LVC> LVC {get;set;} = new();
	[SectionPosition(4)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(5)] public IM_IntermodalMovementInformation? IntermodalMovementInformation { get; set; }
	[SectionPosition(6)] public List<M12_InBondIdentifyingInformation> InBondIdentifyingInformation { get; set; } = new();
	[SectionPosition(7)] public G4_ScaleIdentification? ScaleIdentification { get; set; }
	[SectionPosition(8)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(9)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	[SectionPosition(10)] public H5_CarServiceOrder? CarServiceOrder { get; set; }
	[SectionPosition(11)] public List<LN7_LE1> LE1 {get;set;} = new();
	[SectionPosition(12)] public List<GA_CanadianGrainInformation> CanadianGrainInformation { get; set; } = new();
	[SectionPosition(13)] public List<LN7_LREF> LREF {get;set;} = new();
	[SectionPosition(14)] public List<IMA_InterchangeMoveAuthority> InterchangeMoveAuthority { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.InBondIdentifyingInformation, 0, 2);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.CanadianGrainInformation, 0, 15);
		validator.CollectionSize(x => x.InterchangeMoveAuthority, 0, 3);
		validator.CollectionSize(x => x.LVC, 0, 36);
		validator.CollectionSize(x => x.LE1, 0, 2);
		validator.CollectionSize(x => x.LREF, 0, 99);
		foreach (var item in LVC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LE1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
