using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._135;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public LQ_IndustryCodeIdentification? IndustryCodeIdentification { get; set; }
	[SectionPosition(3)] public SAD_StudentAwardDetail? StudentAwardDetail { get; set; }
	[SectionPosition(4)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(7)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(8)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
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
