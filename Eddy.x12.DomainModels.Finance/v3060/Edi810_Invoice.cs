using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Finance.v3060._810;

namespace Eddy.x12.DomainModels.Finance.v3060;

public class Edi810_Invoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BIG_BeginningSegmentForInvoice BeginningSegmentForInvoice { get; set; } = new();
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(4)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(6)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(9)] public List<ITD_TermsOfSaleDeferredTermsOfSale> TermsOfSaleDeferredTermsOfSale { get; set; } = new();
	[SectionPosition(10)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(11)] public FOB_FOBRelatedInstructions? FOBRelatedInstructions { get; set; }
	[SectionPosition(12)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(13)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(14)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(15)] public List<PKG_MarkingPackagingLoading> MarkingPackagingLoading { get; set; } = new();
	[SectionPosition(16)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(17)] public List<AT_FinancialAccounting> FinancialAccounting { get; set; } = new();
	[SectionPosition(18)] public List<BAL_BalanceDetail> BalanceDetail { get; set; } = new();
	[SectionPosition(19)] public INC_InstallmentInformation? InstallmentInformation { get; set; }
	[SectionPosition(20)] public List<LLM> LLM {get;set;} = new();
	[SectionPosition(21)] public List<LN9> LN9 {get;set;} = new();
	[SectionPosition(22)] public List<LV1> LV1 {get;set;} = new();

	//Details
	[SectionPosition(23)] public List<LIT1> LIT1 {get;set;} = new();

	//Summary
	[SectionPosition(24)] public TDS_TotalMonetaryValueSummary TotalMonetaryValueSummary { get; set; } = new();
	[SectionPosition(25)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(26)] public CAD_CarrierDetail? CarrierDetail { get; set; }
	[SectionPosition(27)] public List<LSAC> LSAC {get;set;} = new();
	[SectionPosition(28)] public List<LISS> LISS {get;set;} = new();
	[SectionPosition(29)] public CTT_TransactionTotals? TransactionTotals { get; set; }
	[SectionPosition(30)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi810_Invoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForInvoice);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 12);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 10);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.TermsOfSaleDeferredTermsOfSale, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 200);
		validator.CollectionSize(x => x.Measurements, 0, 40);
		validator.CollectionSize(x => x.Paperwork, 0, 25);
		validator.CollectionSize(x => x.MarkingPackagingLoading, 0, 25);
		validator.CollectionSize(x => x.FinancialAccounting, 1, 2147483647);
		validator.CollectionSize(x => x.BalanceDetail, 0, 2);
		

		validator.CollectionSize(x => x.LN1, 0, 200);
		validator.CollectionSize(x => x.LLM, 0, 10);
		validator.CollectionSize(x => x.LV1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LV1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LIT1, 0, 200000);
		foreach (var item in LIT1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalMonetaryValueSummary);
		validator.CollectionSize(x => x.TaxInformation, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LSAC, 0, 25);
		validator.CollectionSize(x => x.LISS, 1, 2147483647);
		foreach (var item in LSAC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LISS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
