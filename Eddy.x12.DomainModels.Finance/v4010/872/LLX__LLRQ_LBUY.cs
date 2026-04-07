using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._872;

public class LLX__LLRQ_LBUY {
	[SectionPosition(1)] public BUY_LoanBuydown LoanBuydown { get; set; } = new();
	[SectionPosition(2)] public List<TBA_TemporaryBuydownAdjustment> TemporaryBuydownAdjustment { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LLRQ_LBUY>(this);
		validator.Required(x => x.LoanBuydown);
		validator.CollectionSize(x => x.TemporaryBuydownAdjustment, 0, 10);
		return validator.Results;
	}
}
