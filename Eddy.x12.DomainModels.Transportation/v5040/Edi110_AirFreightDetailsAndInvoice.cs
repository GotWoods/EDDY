using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;
using Eddy.x12.DomainModels.Transportation.v5040._110;

namespace Eddy.x12.DomainModels.Transportation.v5040;

public class Edi110_AirFreightDetailsAndInvoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B3_BeginningSegmentForCarriersInvoice BeginningSegmentForCarriersInvoice { get; set; } = new();
	[SectionPosition(3)] public B3A_InvoiceType? InvoiceType { get; set; }
	[SectionPosition(4)] public C2_BankID? BankID { get; set; }
	[SectionPosition(5)] public C3_CurrencyIdentifier? CurrencyIdentifier { get; set; }
	[SectionPosition(6)] public ITD_TermsOfSaleDeferredTermsOfSale? TermsOfSaleDeferredTermsOfSale { get; set; }
	[SectionPosition(7)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(8)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(9)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(10)] public ACS_AncillaryCharges? AncillaryCharges { get; set; }
	[SectionPosition(11)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi110_AirFreightDetailsAndInvoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarriersInvoice);
		

		validator.CollectionSize(x => x.LN1, 0, 3);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
