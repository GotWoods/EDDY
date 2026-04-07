using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._189;

public class LRQS {
	[SectionPosition(1)] public RQS_RequestForInformation RequestForInformation { get; set; } = new();
	[SectionPosition(2)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRQS>(this);
		validator.Required(x => x.RequestForInformation);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		return validator.Results;
	}
}
