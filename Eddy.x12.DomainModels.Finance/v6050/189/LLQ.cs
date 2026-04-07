using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._189;

public class LLQ {
	[SectionPosition(1)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public PDL_PaymentDetails? PaymentDetails { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLQ>(this);
		validator.Required(x => x.IndustryCodeIdentification);
		return validator.Results;
	}
}
