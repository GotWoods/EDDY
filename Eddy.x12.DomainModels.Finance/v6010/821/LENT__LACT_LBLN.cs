using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._821;

public class LENT__LACT_LBLN {
	[SectionPosition(1)] public BLN_BalanceInformation BalanceInformation { get; set; } = new();
	[SectionPosition(2)] public List<AVA_FundsAvailability> FundsAvailability { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LACT_LBLN>(this);
		validator.Required(x => x.BalanceInformation);
		validator.CollectionSize(x => x.FundsAvailability, 1, 2147483647);
		return validator.Results;
	}
}
