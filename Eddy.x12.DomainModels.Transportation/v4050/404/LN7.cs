using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._404;

public class LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EM_EquipmentCharacteristics? EquipmentCharacteristics { get; set; }
	[SectionPosition(3)] public List<LN7_LVC> LVC {get;set;} = new();
	[SectionPosition(4)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(5)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	[SectionPosition(6)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(7)] public IM_IntermodalMovementInformation? IntermodalMovementInformation { get; set; }
	[SectionPosition(8)] public List<M12_InBondIdentifyingInformation> InBondIdentifyingInformation { get; set; } = new();
	[SectionPosition(9)] public List<LN7_LE1> LE1 {get;set;} = new();
	[SectionPosition(10)] public List<GA_CanadianGrainInformation> CanadianGrainInformation { get; set; } = new();
	[SectionPosition(11)] public List<LN7_LREF> LREF {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.InBondIdentifyingInformation, 0, 2);
		validator.CollectionSize(x => x.CanadianGrainInformation, 0, 15);
		validator.CollectionSize(x => x.LVC, 0, 36);
		validator.CollectionSize(x => x.LE1, 0, 2);
		validator.CollectionSize(x => x.LREF, 0, 99);
		foreach (var item in LVC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LE1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
