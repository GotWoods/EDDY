using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Transportation.v8030._435;

public class LSID_LLQ {
	[SectionPosition(1)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSID_LLQ>(this);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.MessageText, 0, 100);
		return validator.Results;
	}
}
