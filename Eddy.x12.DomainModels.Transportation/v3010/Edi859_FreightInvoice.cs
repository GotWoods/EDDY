using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;
using Eddy.x12.DomainModels.Transportation.v3010._859;

namespace Eddy.x12.DomainModels.Transportation.v3010;

public class Edi859_FreightInvoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B3_BeginningSegmentForCarriersInvoice BeginningSegmentForCarriersInvoice { get; set; } = new();
	[SectionPosition(3)] public B3A_InvoiceType? InvoiceType { get; set; }
	[SectionPosition(4)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public CM_CargoManifest? CargoManifest { get; set; }
	[SectionPosition(6)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(7)] public Y7_Priority? Priority { get; set; }
	[SectionPosition(8)] public C3_Currency? Currency { get; set; }
	[SectionPosition(9)] public ITD_TermsOfSaleDeferredTermsOfSale? TermsOfSaleDeferredTermsOfSale { get; set; }
	[SectionPosition(10)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(11)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(12)] public List<NA_CrossReferenceEquipment> CrossReferenceEquipment { get; set; } = new();
	[SectionPosition(13)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(14)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(15)] public R1_RouteInformationAir? RouteInformationAir { get; set; }
	[SectionPosition(16)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(17)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(18)] public List<PS_ProtectiveServiceInstructions> ProtectiveServiceInstructions { get; set; } = new();
	[SectionPosition(19)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(20)] public M1_Insurance? Insurance { get; set; }
	[SectionPosition(21)] public M2_SalesDeliveryTerms? SalesDeliveryTerms { get; set; }
	[SectionPosition(22)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	[SectionPosition(23)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(24)] public XH_ProFormaB13Information? ProFormaB13Information { get; set; }
	[SectionPosition(25)] public GA_CanadianGrainInformation? CanadianGrainInformation { get; set; }
	[SectionPosition(26)] public P1_PickUp? PickUp { get; set; }
	[SectionPosition(27)] public ITA_AllowanceChargeOrService? AllowanceChargeOrService { get; set; }
	[SectionPosition(28)] public List<N8_WaybillReference> WaybillReference { get; set; } = new();
	[SectionPosition(29)] public R9_RouteCode? RouteCode { get; set; }
	[SectionPosition(30)] public List<LH1> LH1 {get;set;} = new();
	[SectionPosition(31)] public List<LN7> LN7 {get;set;} = new();
	[SectionPosition(32)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(33)] public List<LS5> LS5 {get;set;} = new();

	//Details
	[SectionPosition(34)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(35)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(36)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi859_FreightInvoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarriersInvoice);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 30);
		validator.CollectionSize(x => x.Authentication, 0, 4);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.CrossReferenceEquipment, 0, 30);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.ProtectiveServiceInstructions, 0, 5);
		validator.CollectionSize(x => x.SpecialServices, 0, 6);
		validator.CollectionSize(x => x.TariffReference, 0, 30);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 30);
		validator.CollectionSize(x => x.WaybillReference, 0, 255);
		

		validator.CollectionSize(x => x.LH1, 0, 3);
		validator.CollectionSize(x => x.LN7, 0, 600);
		validator.CollectionSize(x => x.LN1, 0, 10);
		validator.CollectionSize(x => x.LS5, 0, 50);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LS5) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLX, 1, 999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
