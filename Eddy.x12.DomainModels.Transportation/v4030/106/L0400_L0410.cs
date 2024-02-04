using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._106;

public class L0400_L0410 {
	[SectionPosition(1)] public TF_TariffInformation TariffInformation { get; set; } = new();
	[SectionPosition(2)] public TS_TariffSection? TariffSection { get; set; }
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400_L0410>(this);
		validator.Required(x => x.TariffInformation);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		return validator.Results;
	}
}
