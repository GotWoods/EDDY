using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._218;

public class LSCL_LCL {
	[SectionPosition(1)] public CL_Class Class { get; set; } = new();
	[SectionPosition(2)] public TFA_TariffAdjustments? TariffAdjustments { get; set; }
	[SectionPosition(3)] public List<TFD_TariffAdjustmentsMinimumCharge> TariffAdjustmentsMinimumCharge { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSCL_LCL>(this);
		validator.Required(x => x.Class);
		validator.CollectionSize(x => x.TariffAdjustmentsMinimumCharge, 0, 10);
		return validator.Results;
	}
}
