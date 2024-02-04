using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._304;

public class LLX__LL0_LPAL {
	[SectionPosition(1)] public PAL_PalletInformation PalletInformation { get; set; } = new();
	[SectionPosition(2)] public QTY_Quantity? Quantity { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL0_LPAL>(this);
		validator.Required(x => x.PalletInformation);
		return validator.Results;
	}
}
