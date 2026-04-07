using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._822;

public class LENT_LACT {
	[SectionPosition(1)] public ACT_AccountIdentification AccountIdentification { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(3)] public List<ADJ_AdjustmentsToBalancesOrServices> AdjustmentsToBalancesOrServices { get; set; } = new();
	[SectionPosition(4)] public List<LENT__LACT_LRTE> LRTE {get;set;} = new();
	[SectionPosition(5)] public List<LENT__LACT_LLX> LLX {get;set;} = new();
	[SectionPosition(6)] public List<LENT__LACT_LSER> LSER {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT_LACT>(this);
		validator.Required(x => x.AccountIdentification);
		validator.CollectionSize(x => x.AdjustmentsToBalancesOrServices, 0, 1000);
		validator.CollectionSize(x => x.LRTE, 1, 2147483647);
		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		validator.CollectionSize(x => x.LSER, 1, 2147483647);
		foreach (var item in LRTE) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSER) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
