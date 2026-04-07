using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._135;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public LQ_IndustryCode? IndustryCodeIdentification { get; set; }
	[SectionPosition(3)] public SAD_StudentAwardDetail? StudentAwardDetail { get; set; }
	[SectionPosition(4)] public List<AMT_MonetaryAmount> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(7)] public List<QTY_Quantity> QuantityInformation { get; set; } = new();
	[SectionPosition(8)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 15);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 15);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 5);
		validator.CollectionSize(x => x.QuantityInformation, 0, 5);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 2);
		return validator.Results;
	}
}
