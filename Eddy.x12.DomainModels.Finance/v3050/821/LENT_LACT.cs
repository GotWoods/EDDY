using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._821;

public class LENT_LACT {
	[SectionPosition(1)] public ACT_AccountIdentification AccountIdentification { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(3)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(4)] public List<LENT__LACT_LBLN> LBLN {get;set;} = new();
	[SectionPosition(5)] public List<LENT__LACT_LTSU> LTSU {get;set;} = new();
	[SectionPosition(6)] public List<LENT__LACT_LFIR> LFIR {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT_LACT>(this);
		validator.Required(x => x.AccountIdentification);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.LBLN, 1, 2147483647);
		validator.CollectionSize(x => x.LTSU, 1, 2147483647);
		validator.CollectionSize(x => x.LFIR, 1, 2147483647);
		foreach (var item in LBLN) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTSU) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFIR) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
