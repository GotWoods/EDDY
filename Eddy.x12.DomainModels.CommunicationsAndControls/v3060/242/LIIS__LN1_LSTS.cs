using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3060._242;

public class LIIS__LN1_LSTS {
	[SectionPosition(1)] public STS_InterchangeStatusSegment InterchangeStatusSegment { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<QTY_Quantity> Quantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIIS__LN1_LSTS>(this);
		validator.Required(x => x.InterchangeStatusSegment);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		return validator.Results;
	}
}
