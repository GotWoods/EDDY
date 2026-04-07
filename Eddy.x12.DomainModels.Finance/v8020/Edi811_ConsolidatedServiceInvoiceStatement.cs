using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;
using Eddy.x12.DomainModels.Finance.v8020._811;

namespace Eddy.x12.DomainModels.Finance.v8020;

public class Edi811_ConsolidatedServiceInvoiceStatement {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BIG_BeginningSegmentForInvoice BeginningSegmentForInvoice { get; set; } = new();
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(4)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<ITD_TermsOfSaleDeferredTermsOfSale> TermsOfSaleDeferredTermsOfSale { get; set; } = new();
	[SectionPosition(8)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(9)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(10)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(11)] public List<LFA1> LFA1 {get;set;} = new();

	//Details
	[SectionPosition(12)] public List<LHL> LHL {get;set;} = new();

	//Summary
	[SectionPosition(13)] public TDS_TotalMonetaryValueSummary TotalMonetaryValueSummary { get; set; } = new();
	[SectionPosition(14)] public List<LITA> LITA {get;set;} = new();
	[SectionPosition(15)] public List<LBAL> LBAL {get;set;} = new();
	[SectionPosition(16)] public List<LN1> LN12 {get;set;} = new();
	[SectionPosition(17)] public CTT_TransactionTotals? TransactionTotals { get; set; }
	[SectionPosition(18)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi811_ConsolidatedServiceInvoiceStatement>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForInvoice);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.TermsOfSaleDeferredTermsOfSale, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		

		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LHL, 1, 2147483647);
		foreach (var item in LHL) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalMonetaryValueSummary);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LITA, 1, 2147483647);
		validator.CollectionSize(x => x.LBAL, 1, 2147483647);
		validator.CollectionSize(x => x.LN12, 1, 2147483647);
		foreach (var item in LITA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LBAL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
