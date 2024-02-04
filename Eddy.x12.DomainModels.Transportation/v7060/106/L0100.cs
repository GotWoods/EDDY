using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Transportation.v7060._106;

public class L0100 {
	[SectionPosition(1)] public TF_TariffInformation TariffInformation { get; set; } = new();
	[SectionPosition(2)] public TS_TariffSection? TariffSection { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100>(this);
		validator.Required(x => x.TariffInformation);
		return validator.Results;
	}
}
