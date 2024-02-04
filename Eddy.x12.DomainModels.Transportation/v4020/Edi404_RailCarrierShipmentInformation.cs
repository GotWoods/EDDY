using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;
using Eddy.x12.DomainModels.Transportation.v4020._404;

namespace Eddy.x12.DomainModels.Transportation.v4020;

public class Edi404_RailCarrierShipmentInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ZC1_BeginningSegmentForDataCorrectionOrChange? BeginningSegmentForDataCorrectionOrChange { get; set; }
	[SectionPosition(3)] public BX_GeneralShipmentInformation? GeneralShipmentInformation { get; set; }
	[SectionPosition(4)] public BNX_RailShipmentInformation? RailShipmentInformation { get; set; }
	[SectionPosition(5)] public M3_Release Release { get; set; } = new();
	[SectionPosition(6)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(7)] public List<CM_CargoManifest> CargoManifest { get; set; } = new();
	[SectionPosition(8)] public M1_Insurance? Insurance { get; set; }
	[SectionPosition(9)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(10)] public List<LN7> LN7 {get;set;} = new();
	[SectionPosition(11)] public List<NA_CrossReferenceEquipment> CrossReferenceEquipment { get; set; } = new();
	[SectionPosition(12)] public F9_OriginStation OriginStation { get; set; } = new();
	[SectionPosition(13)] public D9_DestinationStation DestinationStation { get; set; } = new();
	[SectionPosition(14)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(15)] public List<LS1> LS1 {get;set;} = new();
	[SectionPosition(16)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(17)] public R9_RouteCode? RouteCode { get; set; }
	[SectionPosition(18)] public List<LE1> LE1 {get;set;} = new();
	[SectionPosition(19)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(20)] public List<PS_ProtectiveServiceInstructions> ProtectiveServiceInstructions { get; set; } = new();
	[SectionPosition(21)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(22)] public List<LT1> LT1 {get;set;} = new();
	[SectionPosition(23)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(24)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(25)] public List<LLH1> LLH1 {get;set;} = new();
	[SectionPosition(26)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(27)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(28)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(29)] public LHR_HazardousMaterialIdentifyingReferenceNumbers? HazardousMaterialIdentifyingReferenceNumbers { get; set; }
	[SectionPosition(30)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(31)] public XH_ProFormaB13Information? ProFormaB13Information { get; set; }
	[SectionPosition(32)] public List<X7_CustomsInformation> CustomsInformation { get; set; } = new();
	[SectionPosition(33)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi404_RailCarrierShipmentInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.Release);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 30);
		validator.CollectionSize(x => x.CargoManifest, 0, 2);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.CollectionSize(x => x.CrossReferenceEquipment, 0, 10);
		validator.Required(x => x.OriginStation);
		validator.Required(x => x.DestinationStation);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 20);
		validator.CollectionSize(x => x.ProtectiveServiceInstructions, 0, 5);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 6);
		validator.CollectionSize(x => x.HazardousCertification, 0, 5);
		validator.CollectionSize(x => x.CustomsInformation, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN7, 1, 500);
		validator.CollectionSize(x => x.LN1, 1, 15);
		validator.CollectionSize(x => x.LS1, 0, 12);
		validator.CollectionSize(x => x.LE1, 0, 2);
		validator.CollectionSize(x => x.LLX, 1, 25);
		validator.CollectionSize(x => x.LT1, 0, 64);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LS1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LE1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LT1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
