using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._218;

public class LLX__LLX__LSCL_LCL {
	[SectionPosition(1)] public CL_Class Class { get; set; } = new();
	[SectionPosition(2)] public RTS_TariffRates? TariffRates { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LLX__LSCL_LCL>(this);
		validator.Required(x => x.Class);
		return validator.Results;
	}
}
