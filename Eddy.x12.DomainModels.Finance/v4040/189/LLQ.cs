using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._189;

public class LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public PDL_PaymentDetails? PaymentDetails { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLQ>(this);
		validator.Required(x => x.IndustryCode);
		return validator.Results;
	}
}
