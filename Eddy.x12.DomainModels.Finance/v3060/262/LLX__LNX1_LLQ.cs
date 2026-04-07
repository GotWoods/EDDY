using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._262;

public class LLX__LNX1_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceIdentification? ReferenceIdentification { get; set; }
	[SectionPosition(3)] public QTY_Quantity? Quantity { get; set; }
	[SectionPosition(4)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(5)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(6)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LNX1_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 7);
		validator.CollectionSize(x => x.MessageText, 0, 3);
		return validator.Results;
	}
}
