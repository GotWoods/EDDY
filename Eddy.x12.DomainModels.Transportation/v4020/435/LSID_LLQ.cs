using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._435;

public class LSID_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSID_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		validator.CollectionSize(x => x.MessageText, 0, 100);
		return validator.Results;
	}
}
