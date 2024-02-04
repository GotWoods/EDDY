using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;
using Eddy.x12.DomainModels.Transportation.v7060._210;

namespace Eddy.x12.DomainModels.Transportation.v7060;

public class Edi210_MotorCarrierFreightDetailsAndInvoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B3_BeginningSegmentForCarriersInvoice BeginningSegmentForCarriersInvoice { get; set; } = new();
	[SectionPosition(3)] public C2_BankID? BankID { get; set; }
	[SectionPosition(4)] public C3_CurrencyIdentifier? CurrencyIdentifier { get; set; }
	[SectionPosition(5)] public ITD_TermsOfSaleDeferredTermsOfSale? TermsOfSaleDeferredTermsOfSale { get; set; }
	[SectionPosition(6)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(7)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(8)] public List<R3_RouteInformationMotor> RouteInformationMotor { get; set; } = new();
	[SectionPosition(9)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(10)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(11)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(12)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(13)] public List<L0250> L0250 {get;set;} = new();

	//Details
	[SectionPosition(14)] public List<L0300> L0300 {get;set;} = new();
	[SectionPosition(15)] public List<L0400> L0400 {get;set;} = new();

	//Summary
	[SectionPosition(16)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(17)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi210_MotorCarrierFreightDetailsAndInvoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarriersInvoice);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 300);
		validator.CollectionSize(x => x.DateTime, 0, 6);
		validator.CollectionSize(x => x.RouteInformationMotor, 0, 12);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		validator.CollectionSize(x => x.L0200, 0, 10);
		validator.CollectionSize(x => x.L0250, 0, 999999);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0250) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L0300, 0, 999);
		validator.CollectionSize(x => x.L0400, 1, 2147483647);
		foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0400) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
