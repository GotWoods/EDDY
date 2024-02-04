using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Transportation.v5020._204;

public class L1000 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public L4_Measurement? Measurement { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		return validator.Results;
	}
}
