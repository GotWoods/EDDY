using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._527;

public class LLIN__LRCD_LQTY {
	[SectionPosition(1)] public QTY_QuantityInformation QuantityInformation { get; set; } = new();
	[SectionPosition(2)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(3)] public List<LLIN__LRCD__LQTY_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN__LRCD_LQTY>(this);
		validator.Required(x => x.QuantityInformation);
		validator.CollectionSize(x => x.LLM, 0, 100);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
