using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Transportation.v8030._301;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(3)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(4)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(5)] public List<LLX_LL0> LL0 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.LL0, 1, 999);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
