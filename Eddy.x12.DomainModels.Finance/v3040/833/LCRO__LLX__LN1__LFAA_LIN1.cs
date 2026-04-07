using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._833;

public class LCRO__LLX__LN1__LFAA_LIN1 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public FPT_FinancialParticipation? FinancialParticipation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO__LLX__LN1__LFAA_LIN1>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 0, 10);
		return validator.Results;
	}
}
