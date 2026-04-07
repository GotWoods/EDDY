using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._202;

public class LN9__LDEX__LNM1__LLX_LLN1 {
	[SectionPosition(1)] public LN1_LoanSpecificData LoanSpecificData { get; set; } = new();
	[SectionPosition(2)] public YNQ_YesNoQuestion? YesNoQuestion { get; set; }
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9__LDEX__LNM1__LLX_LLN1>(this);
		validator.Required(x => x.LoanSpecificData);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		return validator.Results;
	}
}
