using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Transportation.v3020._210;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi210_MotorCarrierFreightDetailsAndInvoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B3_BeginningSegmentForCarriersInvoice BeginningSegmentForCarriersInvoice { get; set; } = new();
	[SectionPosition(3)] public C2_BankID? BankID { get; set; }
	[SectionPosition(4)] public C3_Currency? Currency { get; set; }
	[SectionPosition(5)] public ITD_TermsOfSaleDeferredTermsOfSale? TermsOfSaleDeferredTermsOfSale { get; set; }
	[SectionPosition(6)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(7)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(8)] public List<R3_RouteInformationMotor> RouteInformationMotor { get; set; } = new();
	[SectionPosition(9)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(10)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(11)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(12)] public List<LN7> LN7 {get;set;} = new();

	//Details
	[SectionPosition(13)] public List<LS5> LS5 {get;set;} = new();
	[SectionPosition(14)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(15)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(16)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi210_MotorCarrierFreightDetailsAndInvoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarriersInvoice);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.DateTime, 0, 6);
		validator.CollectionSize(x => x.RouteInformationMotor, 0, 12);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		

		validator.CollectionSize(x => x.LN1, 0, 10);
		validator.CollectionSize(x => x.LN7, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LS5, 0, 999);
		validator.CollectionSize(x => x.LLX, 0, 999);
		foreach (var item in LS5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
