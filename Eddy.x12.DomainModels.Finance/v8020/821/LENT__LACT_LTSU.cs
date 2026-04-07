using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._821;

public class LENT__LACT_LTSU {
	[SectionPosition(1)] public TSU_TransactionSummary TransactionSummary { get; set; } = new();
	[SectionPosition(2)] public List<AVA_FundsAvailability> FundsAvailability { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LACT_LTSU>(this);
		validator.Required(x => x.TransactionSummary);
		validator.CollectionSize(x => x.FundsAvailability, 1, 2147483647);
		return validator.Results;
	}
}
