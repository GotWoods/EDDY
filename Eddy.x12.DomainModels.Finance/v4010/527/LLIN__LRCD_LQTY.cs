using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._527;

public class LLIN__LRCD_LQTY {
	[SectionPosition(1)] public QTY_Quantity Quantity { get; set; } = new();
	[SectionPosition(2)] public N1_Name? Name { get; set; }
	[SectionPosition(3)] public List<LLIN__LRCD__LQTY_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN__LRCD_LQTY>(this);
		validator.Required(x => x.Quantity);
		validator.CollectionSize(x => x.LLM, 0, 100);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
