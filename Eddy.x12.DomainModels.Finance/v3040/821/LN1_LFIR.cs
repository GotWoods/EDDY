using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._821;

public class LN1_LFIR {
	[SectionPosition(1)] public FIR_FinancialInformation FinancialInformation { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(3)] public TRN_Trace? Trace { get; set; }
	[SectionPosition(4)] public List<AVA_FundsAvailability> FundsAvailability { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LFIR>(this);
		validator.Required(x => x.FinancialInformation);
		validator.CollectionSize(x => x.ReferenceNumbers, 1, 2147483647);
		validator.CollectionSize(x => x.FundsAvailability, 1, 2147483647);
		return validator.Results;
	}
}
