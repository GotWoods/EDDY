using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._812;

public class LCDD__LN11_LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(3)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDD__LN11_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 10);
		validator.CollectionSize(x => x.PercentAmounts, 0, 2);
		return validator.Results;
	}
}
