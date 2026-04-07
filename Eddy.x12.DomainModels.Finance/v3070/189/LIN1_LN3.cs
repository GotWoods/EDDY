using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._189;

public class LIN1_LN3 {
	[SectionPosition(1)] public N3_AddressInformation AddressInformation { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1_LN3>(this);
		validator.Required(x => x.AddressInformation);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		return validator.Results;
	}
}
