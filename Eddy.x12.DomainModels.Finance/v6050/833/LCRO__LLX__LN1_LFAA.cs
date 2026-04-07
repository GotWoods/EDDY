using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._833;

public class LCRO__LLX__LN1_LFAA {
	[SectionPosition(1)] public FAA_FinancialAssetAccount FinancialAssetAccount { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(4)] public List<LCRO__LLX__LN1__LFAA_LIN1> LIN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO__LLX__LN1_LFAA>(this);
		validator.Required(x => x.FinancialAssetAccount);
		validator.CollectionSize(x => x.Income, 0, 5);
		validator.CollectionSize(x => x.LIN1, 0, 10);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
