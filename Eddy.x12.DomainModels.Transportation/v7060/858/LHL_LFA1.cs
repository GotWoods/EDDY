using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Transportation.v7060._858;

public class LHL_LFA1 {
	[SectionPosition(1)] public FA1_TypeOfFinancialAccountingData TypeOfFinancialAccountingData { get; set; } = new();
	[SectionPosition(2)] public List<FA2_AccountingData> AccountingData { get; set; } = new();
	[SectionPosition(3)] public L10_WeightInformation? WeightInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LFA1>(this);
		validator.Required(x => x.TypeOfFinancialAccountingData);
		validator.CollectionSize(x => x.AccountingData, 1, 2147483647);
		return validator.Results;
	}
}
