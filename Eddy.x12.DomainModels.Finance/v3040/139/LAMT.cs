using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._139;

public class LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmount MonetaryAmount { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public QTY_Quantity? Quantity { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAMT>(this);
		validator.Required(x => x.MonetaryAmount);
		return validator.Results;
	}
}
