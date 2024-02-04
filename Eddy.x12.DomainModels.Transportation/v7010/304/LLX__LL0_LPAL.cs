using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._304;

public class LLX__LL0_LPAL {
	[SectionPosition(1)] public PAL_PalletTypeAndLoadCharacteristics PalletTypeAndLoadCharacteristics { get; set; } = new();
	[SectionPosition(2)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL0_LPAL>(this);
		validator.Required(x => x.PalletTypeAndLoadCharacteristics);
		return validator.Results;
	}
}
