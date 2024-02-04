using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._218;

public class L2700_L2710 {
	[SectionPosition(1)] public CL_Class Class { get; set; } = new();
	[SectionPosition(2)] public TFA_TariffAdjustments? TariffAdjustments { get; set; }
	[SectionPosition(3)] public List<TFD_TariffAdjustmentsMinimumCharge> TariffAdjustmentsMinimumCharge { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2700_L2710>(this);
		validator.Required(x => x.Class);
		validator.CollectionSize(x => x.TariffAdjustmentsMinimumCharge, 0, 10);
		return validator.Results;
	}
}
