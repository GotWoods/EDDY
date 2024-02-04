using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._422;

public class LLX__LF9__LSCR_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public N9_ReferenceIdentification? ReferenceIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LF9__LSCR_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		return validator.Results;
	}
}
