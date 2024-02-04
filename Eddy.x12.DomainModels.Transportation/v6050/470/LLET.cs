using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._470;

public class LLET {
	[SectionPosition(1)] public LET_LoadAndEquipmentType LoadAndEquipmentType { get; set; } = new();
	[SectionPosition(2)] public List<LLET_LMEA> LMEA {get;set;} = new();
	[SectionPosition(3)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(4)] public L10_WeightInformation? WeightInformation { get; set; }
	[SectionPosition(5)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(6)] public List<LLET_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLET>(this);
		validator.Required(x => x.LoadAndEquipmentType);
		validator.CollectionSize(x => x.LMEA, 1, 999);
		validator.CollectionSize(x => x.LLX, 0, 5);
		foreach (var item in LMEA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
