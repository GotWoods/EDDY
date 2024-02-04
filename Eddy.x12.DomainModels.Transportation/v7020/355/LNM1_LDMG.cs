using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._355;

public class LNM1_LDMG {
	[SectionPosition(1)] public DMG_DemographicInformation DemographicInformation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1_LDMG>(this);
		validator.Required(x => x.DemographicInformation);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
