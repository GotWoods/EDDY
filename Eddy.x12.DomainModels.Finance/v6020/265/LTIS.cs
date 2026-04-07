using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._265;

public class LTIS {
	[SectionPosition(1)] public TIS_TitleInsuranceServices TitleInsuranceServices { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(3)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTIS>(this);
		validator.Required(x => x.TitleInsuranceServices);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 30);
		validator.CollectionSize(x => x.MessageText, 0, 100);
		return validator.Results;
	}
}
