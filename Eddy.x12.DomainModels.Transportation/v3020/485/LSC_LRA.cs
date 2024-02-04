using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._485;

public class LSC_LRA {
	[SectionPosition(1)] public RA_RateHeader RateHeader { get; set; } = new();
	[SectionPosition(2)] public List<FK_Factor> Factor { get; set; } = new();
	[SectionPosition(3)] public List<LSC__LRA_LMC> LMC {get;set;} = new();
	[SectionPosition(4)] public List<SW_SwitchingCharges> SwitchingCharges { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSC_LRA>(this);
		validator.Required(x => x.RateHeader);
		validator.CollectionSize(x => x.Factor, 0, 5);
		validator.CollectionSize(x => x.SwitchingCharges, 0, 3);
		validator.CollectionSize(x => x.LMC, 0, 64);
		foreach (var item in LMC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
