using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._130;

public class LIN1_LN3 {
	[SectionPosition(1)] public N3_AddressInformation AddressInformation { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1_LN3>(this);
		validator.Required(x => x.AddressInformation);
		return validator.Results;
	}
}
