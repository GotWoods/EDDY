using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._821;

public class LENT__LACT_LFIR {
	[SectionPosition(1)] public FIR_FinancialInformation FinancialInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(5)] public List<AVA_FundsAvailability> FundsAvailability { get; set; } = new();
	[SectionPosition(6)] public TRN_Trace? Trace { get; set; }
	[SectionPosition(7)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(8)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(9)] public List<CTP_PricingInformation> PricingInformation { get; set; } = new();
	[SectionPosition(10)] public List<RTE_RateInformation> RateInformation { get; set; } = new();
	[SectionPosition(11)] public List<LENT__LACT__LFIR_LNM1> LNM1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LACT_LFIR>(this);
		validator.Required(x => x.FinancialInformation);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.FundsAvailability, 1, 2147483647);
		validator.CollectionSize(x => x.PartyIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PricingInformation, 1, 2147483647);
		validator.CollectionSize(x => x.RateInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
