using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._202;

public class LN9__LDEX__LNM1_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(4)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(5)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(6)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(7)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(8)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(9)] public LUC_LoanUnderwriting? LoanUnderwriting { get; set; }
	[SectionPosition(10)] public List<RLD_DownPaymentData> DownPaymentData { get; set; } = new();
	[SectionPosition(11)] public List<INT_Interest> Interest { get; set; } = new();
	[SectionPosition(12)] public PPD_PaymentPatternDetails? PaymentPatternDetails { get; set; }
	[SectionPosition(13)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(14)] public BUY_LoanBuydown? LoanBuydown { get; set; }
	[SectionPosition(15)] public List<PEX_PropertyOrHousingExpense> PropertyOrHousingExpense { get; set; } = new();
	[SectionPosition(16)] public List<BEP_BorrowerEducationProgram> BorrowerEducationProgram { get; set; } = new();
	[SectionPosition(17)] public List<LN9__LDEX__LNM1__LLX_LIGI> LIGI {get;set;} = new();
	[SectionPosition(18)] public List<LN9__LDEX__LNM1__LLX_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(19)] public List<LN9__LDEX__LNM1__LLX_LLN1> LLN1 {get;set;} = new();
	[SectionPosition(20)] public List<LN9__LDEX__LNM1__LLX_LCRC> LCRC {get;set;} = new();
	[SectionPosition(21)] public List<LN9__LDEX__LNM1__LLX_LPAM> LPAM {get;set;} = new();
	[SectionPosition(22)] public List<LN9__LDEX__LNM1__LLX_LUWI> LUWI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9__LDEX__LNM1_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 15);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 20);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 10);
		validator.CollectionSize(x => x.QuantityInformation, 0, 5);
		validator.CollectionSize(x => x.PartyIdentification, 0, 6);
		validator.CollectionSize(x => x.Information, 0, 50);
		validator.CollectionSize(x => x.DownPaymentData, 0, 50);
		validator.CollectionSize(x => x.Interest, 0, 6);
		validator.CollectionSize(x => x.Paperwork, 0, 2);
		validator.CollectionSize(x => x.PropertyOrHousingExpense, 0, 10);
		validator.CollectionSize(x => x.BorrowerEducationProgram, 0, 2);
		validator.CollectionSize(x => x.LIGI, 1, 2147483647);
		validator.CollectionSize(x => x.LNX1, 1, 2147483647);
		validator.CollectionSize(x => x.LLN1, 0, 5);
		validator.CollectionSize(x => x.LCRC, 1, 2147483647);
		validator.CollectionSize(x => x.LPAM, 0, 4);
		validator.CollectionSize(x => x.LUWI, 0, 5);
		foreach (var item in LIGI) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCRC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPAM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LUWI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
