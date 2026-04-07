using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._872;

public class LLX__LMII_LPRJ {
	[SectionPosition(1)] public PRJ_MultifamilyHousingProject MultifamilyHousingProject { get; set; } = new();
	[SectionPosition(2)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LMII_LPRJ>(this);
		validator.Required(x => x.MultifamilyHousingProject);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 10);
		return validator.Results;
	}
}
