using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._420;

public class LE6 {
	[SectionPosition(1)] public E6_AdvanceCarDisposition AdvanceCarDisposition { get; set; } = new();
	[SectionPosition(2)] public E8_BlockingAndResponseInformation BlockingAndResponseInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE6>(this);
		validator.Required(x => x.AdvanceCarDisposition);
		validator.Required(x => x.BlockingAndResponseInformation);
		return validator.Results;
	}
}
