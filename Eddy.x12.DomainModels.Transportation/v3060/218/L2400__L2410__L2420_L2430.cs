using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._218;

public class L2400__L2410__L2420_L2430 {
	[SectionPosition(1)] public CL_Class Class { get; set; } = new();
	[SectionPosition(2)] public RTS_TariffRates? TariffRates { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2400__L2410__L2420_L2430>(this);
		validator.Required(x => x.Class);
		return validator.Results;
	}
}
