using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._485;

public class L0100_L0110 {
	[SectionPosition(1)] public RA_RateHeader RateHeader { get; set; } = new();
	[SectionPosition(2)] public List<FK_Factor> Factor { get; set; } = new();
	[SectionPosition(3)] public List<L0100__L0110_L0111> L0111 {get;set;} = new();
	[SectionPosition(4)] public List<SW_SwitchingCharges> SwitchingCharges { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100_L0110>(this);
		validator.Required(x => x.RateHeader);
		validator.CollectionSize(x => x.Factor, 0, 5);
		validator.CollectionSize(x => x.SwitchingCharges, 0, 3);
		validator.CollectionSize(x => x.L0111, 0, 64);
		foreach (var item in L0111) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
