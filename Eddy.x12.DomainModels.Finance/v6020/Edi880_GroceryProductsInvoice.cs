using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;
using Eddy.x12.DomainModels.Finance.v6020._880;

namespace Eddy.x12.DomainModels.Finance.v6020;

public class Edi880_GroceryProductsInvoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public G01_InvoiceIdentification InvoiceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<G61_Contact> Contact { get; set; } = new();
	[SectionPosition(5)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(7)] public List<CAD_CarrierDetails> CarrierDetails { get; set; } = new();
	[SectionPosition(8)] public List<G23_TermsOfSale> TermsOfSale { get; set; } = new();
	[SectionPosition(9)] public G25_FOBInformation? FOBInformation { get; set; }
	[SectionPosition(10)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(11)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(12)] public List<L0200> L0200 {get;set;} = new();

	//Details
	[SectionPosition(13)] public List<L0300> L0300 {get;set;} = new();
	[SectionPosition(14)] public List<L0400> L0400 {get;set;} = new();

	//Summary
	[SectionPosition(15)] public G31_TotalInvoiceQuantity TotalInvoiceQuantity { get; set; } = new();
	[SectionPosition(16)] public G33_TotalDollarsSummary TotalDollarsSummary { get; set; } = new();
	[SectionPosition(17)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi880_GroceryProductsInvoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.InvoiceIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.Contact, 0, 3);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 20);
		validator.CollectionSize(x => x.CarrierDetails, 0, 5);
		validator.CollectionSize(x => x.TermsOfSale, 0, 20);
		validator.CollectionSize(x => x.Text, 0, 5);
		

		validator.CollectionSize(x => x.L0100, 1, 10);
		validator.CollectionSize(x => x.L0200, 0, 100);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L0300, 0, 9999);
		validator.CollectionSize(x => x.L0400, 0, 500);
		foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0400) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalInvoiceQuantity);
		validator.Required(x => x.TotalDollarsSummary);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
