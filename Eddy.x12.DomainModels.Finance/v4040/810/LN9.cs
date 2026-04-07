using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._810;

public class LN9 {
	[SectionPosition(1)] public N9_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9>(this);
		validator.Required(x => x.ReferenceIdentification);
		validator.CollectionSize(x => x.MessageText, 1, 10);
		return validator.Results;
	}
}
