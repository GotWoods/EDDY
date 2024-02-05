using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3050._242;

public class LIIS__LN1_LSTS {
	[SectionPosition(1)] public STS_InterchangeStatusSegment InterchangeStatusSegment { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIIS__LN1_LSTS>(this);
		validator.Required(x => x.InterchangeStatusSegment);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 10);
		return validator.Results;
	}
}
