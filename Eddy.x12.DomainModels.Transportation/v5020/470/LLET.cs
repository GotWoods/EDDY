using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Transportation.v5020._470;

public class LLET {
	[SectionPosition(1)] public LET_LoadAndEquipmentType LoadAndEquipmentType { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public List<L4_Measurement> Measurement { get; set; } = new();
	[SectionPosition(4)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(5)] public L10_WeightInformation? WeightInformation { get; set; }
	[SectionPosition(6)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(7)] public List<LLET_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLET>(this);
		validator.Required(x => x.LoadAndEquipmentType);
		validator.CollectionSize(x => x.Measurements, 1, 4);
		validator.CollectionSize(x => x.Measurement, 1, 75);
		validator.CollectionSize(x => x.LLX, 1, 5);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
