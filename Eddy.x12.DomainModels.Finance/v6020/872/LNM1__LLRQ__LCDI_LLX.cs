using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._872;

public class LNM1__LLRQ__LCDI_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<VDI_ValueDescriptionOrInformation> ValueDescriptionOrInformation { get; set; } = new();
	[SectionPosition(3)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(4)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(5)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(6)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(7)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(8)] public BUY_LoanBuydown? LoanBuydown { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1__LLRQ__LCDI_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.ValueDescriptionOrInformation, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		return validator.Results;
	}
}
