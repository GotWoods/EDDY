using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._822;

public class LN1_LACT {
	[SectionPosition(1)] public ACT_AccountIdentification AccountIdentification { get; set; } = new();
	[SectionPosition(2)] public List<ADJ_AdjustmentsToBalancesOrServices> AdjustmentsToBalancesOrServices { get; set; } = new();
	[SectionPosition(3)] public List<RTE_RateInformation> RateInformation { get; set; } = new();
	[SectionPosition(4)] public List<LN1__LACT_LBAL> LBAL {get;set;} = new();
	[SectionPosition(5)] public List<LN1__LACT_LSER> LSER {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LACT>(this);
		validator.Required(x => x.AccountIdentification);
		validator.CollectionSize(x => x.AdjustmentsToBalancesOrServices, 0, 1000);
		validator.CollectionSize(x => x.RateInformation, 0, 13);
		validator.CollectionSize(x => x.LBAL, 0, 100);
		validator.CollectionSize(x => x.LSER, 0, 1000);
		foreach (var item in LBAL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSER) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
