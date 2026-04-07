using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._202;

public class LN9__LDEX__LNM1__LLX__LCRC_LSCM {
	[SectionPosition(1)] public SCM_CreditScoreModel CreditScoreModel { get; set; } = new();
	[SectionPosition(2)] public List<SCS_CreditScore> CreditScore { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9__LDEX__LNM1__LLX__LCRC_LSCM>(this);
		validator.Required(x => x.CreditScoreModel);
		validator.CollectionSize(x => x.CreditScore, 0, 5);
		return validator.Results;
	}
}
