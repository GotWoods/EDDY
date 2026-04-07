using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._189;

public class LIN1_LN3 {
	[SectionPosition(1)] public N3_PartyLocation PartyLocation { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1_LN3>(this);
		validator.Required(x => x.PartyLocation);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		return validator.Results;
	}
}
