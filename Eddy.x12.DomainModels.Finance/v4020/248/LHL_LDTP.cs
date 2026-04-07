using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._248;

public class LHL_LDTP {
	[SectionPosition(1)] public DTP_DateOrTimeOrPeriod DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(2)] public List<STC_StatusInformation> StatusInformation { get; set; } = new();
	[SectionPosition(3)] public INT_Interest? Interest { get; set; }
	[SectionPosition(4)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(5)] public List<ACT_AccountIdentification> AccountIdentification { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LDTP>(this);
		validator.Required(x => x.DateOrTimeOrPeriod);
		validator.CollectionSize(x => x.StatusInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 2147483647);
		validator.CollectionSize(x => x.AccountIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		return validator.Results;
	}
}
