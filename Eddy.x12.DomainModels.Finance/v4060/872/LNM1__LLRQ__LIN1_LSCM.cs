using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._872;

public class LNM1__LLRQ__LIN1_LSCM {
	[SectionPosition(1)] public SCM_CreditScoreModel CreditScoreModel { get; set; } = new();
	[SectionPosition(2)] public List<SCS_CreditScore> CreditScore { get; set; } = new();
	[SectionPosition(3)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1__LLRQ__LIN1_LSCM>(this);
		validator.Required(x => x.CreditScoreModel);
		validator.CollectionSize(x => x.CreditScore, 0, 5);
		return validator.Results;
	}
}
