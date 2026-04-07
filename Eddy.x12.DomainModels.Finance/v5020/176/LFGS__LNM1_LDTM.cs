using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._176;

public class LFGS__LNM1_LDTM {
	[SectionPosition(1)] public DTM_DateTimeReference DateTimeReference { get; set; } = new();
	[SectionPosition(2)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFGS__LNM1_LDTM>(this);
		validator.Required(x => x.DateTimeReference);
		validator.CollectionSize(x => x.ConditionsIndicator, 1, 2147483647);
		return validator.Results;
	}
}
