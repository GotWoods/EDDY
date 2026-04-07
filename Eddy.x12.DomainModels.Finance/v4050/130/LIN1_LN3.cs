using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._130;

public class LIN1_LN3 {
	[SectionPosition(1)] public N3_AddressInformation PartyLocation { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1_LN3>(this);
		validator.Required(x => x.PartyLocation);
		return validator.Results;
	}
}
