using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Finance.v7050._820;

public class L2000_L2100 {
	[SectionPosition(1)] public FA1_TypeOfFinancialAccountingData TypeOfFinancialAccountingData { get; set; } = new();
	[SectionPosition(2)] public List<FA2_AccountingData> AccountingData { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2100>(this);
		validator.Required(x => x.TypeOfFinancialAccountingData);
		validator.CollectionSize(x => x.AccountingData, 1, 2147483647);
		return validator.Results;
	}
}
