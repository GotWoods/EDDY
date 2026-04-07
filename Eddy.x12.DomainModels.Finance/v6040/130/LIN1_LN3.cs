using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._130;

public class LIN1_LN3 {
	[SectionPosition(1)] public N3_PartyLocation PartyLocation { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1_LN3>(this);
		validator.Required(x => x.PartyLocation);
		return validator.Results;
	}
}
