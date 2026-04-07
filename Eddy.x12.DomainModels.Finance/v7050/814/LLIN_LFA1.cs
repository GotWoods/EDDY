using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Finance.v7050._814;

public class LLIN_LFA1 {
	[SectionPosition(1)] public FA1_TypeOfFinancialAccountingData TypeOfFinancialAccountingData { get; set; } = new();
	[SectionPosition(2)] public List<FA2_AccountingData> AccountingData { get; set; } = new();
	[SectionPosition(3)] public List<LLIN__LFA1_LAMT> LAMT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN_LFA1>(this);
		validator.Required(x => x.TypeOfFinancialAccountingData);
		validator.CollectionSize(x => x.AccountingData, 1, 2147483647);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
