using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Finance.v3030._810;

namespace Eddy.x12.DomainModels.Finance.v3030;

public class Edi810_Invoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BIG_BeginningSegmentForInvoice BeginningSegmentForInvoice { get; set; } = new();
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(4)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(8)] public List<ITD_TermsOfSaleDeferredTermsOfSale> TermsOfSaleDeferredTermsOfSale { get; set; } = new();
	[SectionPosition(9)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(10)] public FOB_FOBRelatedInstructions? FOBRelatedInstructions { get; set; }
	[SectionPosition(11)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(12)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(13)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(14)] public List<PKG_MarkingPackagingLoading> MarkingPackagingLoading { get; set; } = new();
	[SectionPosition(15)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(16)] public List<AT_FinancialAccounting> FinancialAccounting { get; set; } = new();
	[SectionPosition(17)] public List<LLM> LLM {get;set;} = new();
	[SectionPosition(18)] public List<LN9> LN9 {get;set;} = new();

	//Details
	[SectionPosition(19)] public List<LIT1> LIT1 {get;set;} = new();

	//Summary
	[SectionPosition(20)] public TDS_TotalMonetaryValueSummary TotalMonetaryValueSummary { get; set; } = new();
	[SectionPosition(21)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(22)] public CAD_CarrierDetail? CarrierDetail { get; set; }
	[SectionPosition(23)] public List<LITA> LITA {get;set;} = new();
	[SectionPosition(24)] public List<ISS_InvoiceShipmentSummary> InvoiceShipmentSummary { get; set; } = new();
	[SectionPosition(25)] public CTT_TransactionTotals TransactionTotals { get; set; } = new();
	[SectionPosition(26)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi810_Invoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForInvoice);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 12);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.TermsOfSaleDeferredTermsOfSale, 0, 5);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 200);
		validator.CollectionSize(x => x.Measurements, 0, 40);
		validator.CollectionSize(x => x.Paperwork, 0, 25);
		validator.CollectionSize(x => x.MarkingPackagingLoading, 0, 25);
		validator.CollectionSize(x => x.FinancialAccounting, 0, 3);
		

		validator.CollectionSize(x => x.LN1, 0, 200);
		validator.CollectionSize(x => x.LLM, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN9) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LIT1, 0, 200000);
		foreach (var item in LIT1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalMonetaryValueSummary);
		validator.CollectionSize(x => x.TaxInformation, 0, 10);
		validator.CollectionSize(x => x.InvoiceShipmentSummary, 0, 5);
		validator.Required(x => x.TransactionTotals);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LITA, 0, 10);
		foreach (var item in LITA) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
