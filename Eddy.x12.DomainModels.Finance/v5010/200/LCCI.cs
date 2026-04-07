using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Finance.v5010._200;

public class LCCI {
	[SectionPosition(1)] public CCI_CreditCounselingInformation CreditCounselingInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCCI>(this);
		validator.Required(x => x.CreditCounselingInformation);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 3);
		validator.CollectionSize(x => x.MessageText, 0, 4);
		return validator.Results;
	}
}
