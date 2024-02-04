using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._218;

public class L2200_L2210 {
	[SectionPosition(1)] public CL_Class Class { get; set; } = new();
	[SectionPosition(2)] public RTS_TariffRates? TariffRates { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2200_L2210>(this);
		validator.Required(x => x.Class);
		return validator.Results;
	}
}
