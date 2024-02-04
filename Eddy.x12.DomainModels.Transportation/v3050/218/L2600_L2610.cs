using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._218;

public class L2600_L2610 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public TFA_TariffAdjustments? TariffAdjustments { get; set; }
	[SectionPosition(4)] public List<TFD_TariffAdjustmentsMinimumCharge> TariffAdjustmentsMinimumCharge { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2600_L2610>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.Geography, 0, 99);
		validator.CollectionSize(x => x.TariffAdjustmentsMinimumCharge, 0, 10);
		return validator.Results;
	}
}
