using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._262;

public class LLX_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceNumbers ReferenceNumbers { get; set; } = new();
	[SectionPosition(3)] public QTY_Quantity Quantity { get; set; } = new();
	[SectionPosition(4)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(5)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		validator.Required(x => x.ReferenceNumbers);
		validator.Required(x => x.Quantity);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 7);
		validator.CollectionSize(x => x.MessageText, 0, 3);
		return validator.Results;
	}
}
