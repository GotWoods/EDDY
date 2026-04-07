using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._130;

public class LLX_LHC {
	[SectionPosition(1)] public HC_HealthCondition HealthCondition { get; set; } = new();
	[SectionPosition(2)] public N1_Name? Name { get; set; }
	[SectionPosition(3)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(4)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(5)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LHC>(this);
		validator.Required(x => x.HealthCondition);
		return validator.Results;
	}
}
