using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._262;

public class LLX__LNX1_LIII {
	[SectionPosition(1)] public III_Information Information { get; set; } = new();
	[SectionPosition(2)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LNX1_LIII>(this);
		validator.Required(x => x.Information);
		validator.CollectionSize(x => x.MessageText, 0, 10);
		return validator.Results;
	}
}
