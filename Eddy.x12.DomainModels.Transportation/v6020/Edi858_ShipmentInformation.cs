using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;
using Eddy.x12.DomainModels.Transportation.v6020._858;

namespace Eddy.x12.DomainModels.Transportation.v6020;

public class Edi858_ShipmentInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ZC1_BeginningSegmentForDataCorrectionOrChange? BeginningSegmentForDataCorrectionOrChange { get; set; }
	[SectionPosition(3)] public BX_GeneralShipmentInformation GeneralShipmentInformation { get; set; } = new();
	[SectionPosition(4)] public BNX_RailShipmentInformation? RailShipmentInformation { get; set; }
	[SectionPosition(5)] public M3_Release? Release { get; set; }
	[SectionPosition(6)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<CM_CargoManifest> CargoManifest { get; set; } = new();
	[SectionPosition(8)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(9)] public Y7_CargoBookingPriority? CargoBookingPriority { get; set; }
	[SectionPosition(10)] public C3_CurrencyIdentifier? CurrencyIdentifier { get; set; }
	[SectionPosition(11)] public ITD_TermsOfSaleDeferredTermsOfSale? TermsOfSaleDeferredTermsOfSale { get; set; }
	[SectionPosition(12)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(13)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(14)] public List<NA_CrossReferenceEquipment> CrossReferenceEquipment { get; set; } = new();
	[SectionPosition(15)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(16)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(17)] public R1_RouteInformationAir? RouteInformationAir { get; set; }
	[SectionPosition(18)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(19)] public List<R3_RouteInformationMotor> RouteInformationMotor { get; set; } = new();
	[SectionPosition(20)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	[SectionPosition(21)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(22)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(23)] public List<PS_ProtectiveServiceInstructions> ProtectiveServiceInstructions { get; set; } = new();
	[SectionPosition(24)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(25)] public V4_CargoLocationReference? CargoLocationReference { get; set; }
	[SectionPosition(26)] public V5_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(27)] public List<LE1> LE1 {get;set;} = new();
	[SectionPosition(28)] public M1_Insurance? Insurance { get; set; }
	[SectionPosition(29)] public M2_SalesDeliveryTerms? SalesDeliveryTerms { get; set; }
	[SectionPosition(30)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	[SectionPosition(31)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(32)] public XH_ProFormaB13Information? ProFormaB13Information { get; set; }
	[SectionPosition(33)] public List<LN7> LN7 {get;set;} = new();
	[SectionPosition(34)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(35)] public List<LS5> LS5 {get;set;} = new();
	[SectionPosition(36)] public List<LFA1> LFA1 {get;set;} = new();

	//Details
	[SectionPosition(37)] public List<LHL> LHL {get;set;} = new();

	//Summary
	[SectionPosition(38)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(39)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi858_ShipmentInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.GeneralShipmentInformation);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 30);
		validator.CollectionSize(x => x.CargoManifest, 0, 3);
		validator.CollectionSize(x => x.Authentication, 0, 4);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.CrossReferenceEquipment, 0, 999);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.RouteInformationMotor, 0, 13);
		validator.CollectionSize(x => x.PortOrTerminal, 0, 5);
		validator.CollectionSize(x => x.Measurements, 0, 10);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 20);
		validator.CollectionSize(x => x.ProtectiveServiceInstructions, 0, 5);
		validator.CollectionSize(x => x.SpecialServices, 0, 6);
		validator.CollectionSize(x => x.TariffReference, 0, 30);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 50);
		

		validator.CollectionSize(x => x.LE1, 0, 2);
		validator.CollectionSize(x => x.LN7, 0, 600);
		validator.CollectionSize(x => x.LN1, 0, 12);
		validator.CollectionSize(x => x.LS5, 0, 999);
		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		foreach (var item in LE1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LS5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LHL, 1, 2147483647);
		foreach (var item in LHL) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
