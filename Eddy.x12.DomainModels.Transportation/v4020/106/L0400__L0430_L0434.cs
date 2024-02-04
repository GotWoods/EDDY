using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._106;

public class L0400__L0430_L0434 {
	[SectionPosition(1)] public RTT_FreightRate FreightRate { get; set; } = new();
	[SectionPosition(2)] public List<TFR_TariffRestrictions> TariffRestrictions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400__L0430_L0434>(this);
		validator.Required(x => x.FreightRate);
		validator.CollectionSize(x => x.TariffRestrictions, 0, 10);
		return validator.Results;
	}
}
