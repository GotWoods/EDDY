using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._200;

public class LVAR_LSCM {
	[SectionPosition(1)] public SCM_CreditScoreModel CreditScoreModel { get; set; } = new();
	[SectionPosition(2)] public List<SCS_CreditScore> CreditScore { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LVAR_LSCM>(this);
		validator.Required(x => x.CreditScoreModel);
		validator.CollectionSize(x => x.CreditScore, 0, 5);
		return validator.Results;
	}
}
