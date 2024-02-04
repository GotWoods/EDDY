using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._926;

public class LF11 {
	[SectionPosition(1)] public F11_Status Status { get; set; } = new();
	[SectionPosition(2)] public List<F14_LineItemReject> LineItemReject { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LF11>(this);
		validator.Required(x => x.Status);
		validator.CollectionSize(x => x.LineItemReject, 0, 99);
		return validator.Results;
	}
}
