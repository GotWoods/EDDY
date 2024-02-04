using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._404;

public class LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EM_EquipmentCharacteristics? EquipmentCharacteristics { get; set; }
	[SectionPosition(3)] public REF_ReferenceIdentification? ReferenceIdentification { get; set; }
	[SectionPosition(4)] public List<LN7_LVC> LVC {get;set;} = new();
	[SectionPosition(5)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(6)] public N5_EquipmentOrdered? EquipmentOrdered { get; set; }
	[SectionPosition(7)] public IC_IntermodalChassisEquipment? IntermodalChassisEquipment { get; set; }
	[SectionPosition(8)] public IM_IntermodalMovementInformation? IntermodalMovementInformation { get; set; }
	[SectionPosition(9)] public M12_InBondIdentifyingInformation? InBondIdentifyingInformation { get; set; }
	[SectionPosition(10)] public List<LN7_LE1> LE1 {get;set;} = new();
	[SectionPosition(11)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(12)] public List<GA_CanadianGrainInformation> CanadianGrainInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.CanadianGrainInformation, 0, 15);
		validator.CollectionSize(x => x.LVC, 0, 21);
		validator.CollectionSize(x => x.LE1, 0, 2);
		foreach (var item in LVC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LE1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
