using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._110;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi110_AirFreightDetailsAndInvoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B3_BeginningSegmentForCarriersInvoice BeginningSegmentForCarriersInvoice { get; set; } = new();
	[SectionPosition(3)] public B3A_InvoiceType InvoiceType { get; set; } = new();
	[SectionPosition(4)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public C2_BankID? BankID { get; set; }
	[SectionPosition(6)] public C3_Currency? Currency { get; set; }
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public List<ITD_TermsOfSaleDeferredTermsOfSale> TermsOfSaleDeferredTermsOfSale { get; set; } = new();
	[SectionPosition(9)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(10)] public P1_PickUp? PickUp { get; set; }
	[SectionPosition(11)] public POD_ProofOfDelivery? ProofOfDelivery { get; set; }
	[SectionPosition(12)] public V9_EventDetail? EventDetail { get; set; }
	[SectionPosition(13)] public List<R1_RouteInformationAir> RouteInformationAir { get; set; } = new();

	//Details
	[SectionPosition(14)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(15)] public List<L4_Measurement> Measurement { get; set; } = new();
	[SectionPosition(16)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(17)] public SL1_TariffReference? TariffReference { get; set; }
	[SectionPosition(18)] public List<L10_Weight> Weight { get; set; } = new();
	[SectionPosition(19)] public List<ACS_AncillaryCharges> AncillaryCharges { get; set; } = new();
	[SectionPosition(20)] public G47_StatementIdentification? StatementIdentification { get; set; }
	[SectionPosition(21)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(22)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi110_AirFreightDetailsAndInvoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarriersInvoice);
		validator.Required(x => x.InvoiceType);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 25);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.TermsOfSaleDeferredTermsOfSale, 0, 2);
		validator.CollectionSize(x => x.RouteInformationAir, 0, 2);
		

		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLX, 1, 99999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.CollectionSize(x => x.Measurement, 0, 30);
		validator.CollectionSize(x => x.Weight, 0, 30);
		validator.CollectionSize(x => x.AncillaryCharges, 0, 100);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
