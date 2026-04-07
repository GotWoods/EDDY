using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._833;

public class LCRO__LLX_LREA {
	[SectionPosition(1)] public REA_RealEstatePropertyInformation RealEstatePropertyInformation { get; set; } = new();
	[SectionPosition(2)] public FPT_FinancialParticipation? FinancialParticipation { get; set; }
	[SectionPosition(3)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(4)] public NX1_PropertyOrEntityIdentification? PropertyOrEntityIdentification { get; set; }
	[SectionPosition(5)] public List<NX2_RealEstatePropertyIDComponent> RealEstatePropertyIDComponent { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO__LLX_LREA>(this);
		validator.Required(x => x.RealEstatePropertyInformation);
		validator.CollectionSize(x => x.Income, 0, 5);
		validator.CollectionSize(x => x.RealEstatePropertyIDComponent, 0, 30);
		return validator.Results;
	}
}
