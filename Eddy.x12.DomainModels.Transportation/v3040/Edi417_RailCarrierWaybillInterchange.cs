using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;
using Eddy.x12.DomainModels.Transportation.v3040._417;

namespace Eddy.x12.DomainModels.Transportation.v3040;

public class Edi417_RailCarrierWaybillInterchange {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ZC1_BeginningSegmentForDataCorrectionOrChange? BeginningSegmentForDataCorrectionOrChange { get; set; }
	[SectionPosition(3)] public BX_GeneralShipmentInformation? GeneralShipmentInformation { get; set; }
	[SectionPosition(4)] public BNX_RailShipmentInformation? RailShipmentInformation { get; set; }
	[SectionPosition(5)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<CM_CargoManifest> CargoManifest { get; set; } = new();
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public List<LN7> LN7 {get;set;} = new();
	[SectionPosition(9)] public List<IMA_InterchangeMoveAuthority> InterchangeMoveAuthority { get; set; } = new();
	[SectionPosition(10)] public List<N8_WaybillReference> WaybillReference { get; set; } = new();
	[SectionPosition(11)] public V9_EventDetail? EventDetail { get; set; }
	[SectionPosition(12)] public F9_OriginStation OriginStation { get; set; } = new();
	[SectionPosition(13)] public D9_DestinationStation DestinationStation { get; set; } = new();
	[SectionPosition(14)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(15)] public List<LS1> LS1 {get;set;} = new();
	[SectionPosition(16)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(17)] public RE_RebillAtInterchange? RebillAtInterchange { get; set; }
	[SectionPosition(18)] public E1_EmptyCarDispositionPendedDestinationConsignee? EmptyCarDispositionPendedDestinationConsignee { get; set; }
	[SectionPosition(19)] public E4_EmptyCarDispositionPendedDestinationCity? EmptyCarDispositionPendedDestinationCity { get; set; }
	[SectionPosition(20)] public List<E5_EmptyCarDispositionPendedDestinationRoute> EmptyCarDispositionPendedDestinationRoute { get; set; } = new();
	[SectionPosition(21)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(22)] public PS_ProtectiveServiceInstructions? ProtectiveServiceInstructions { get; set; }
	[SectionPosition(23)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(24)] public List<LT1> LT1 {get;set;} = new();
	[SectionPosition(25)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(26)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(27)] public List<LLH1> LLH1 {get;set;} = new();
	[SectionPosition(28)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(29)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(30)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(31)] public LHR_HazardousMaterialIdentifyingReferenceNumbers? HazardousMaterialIdentifyingReferenceNumbers { get; set; }
	[SectionPosition(32)] public List<X7_CustomsInformation> CustomsInformation { get; set; } = new();
	[SectionPosition(33)] public GA_CanadianGrainInformation? CanadianGrainInformation { get; set; }
	[SectionPosition(34)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi417_RailCarrierWaybillInterchange>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 30);
		validator.CollectionSize(x => x.CargoManifest, 0, 2);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.CollectionSize(x => x.InterchangeMoveAuthority, 0, 3);
		validator.CollectionSize(x => x.WaybillReference, 0, 499);
		validator.Required(x => x.OriginStation);
		validator.Required(x => x.DestinationStation);
		validator.CollectionSize(x => x.RouteInformation, 1, 13);
		validator.CollectionSize(x => x.EmptyCarDispositionPendedDestinationRoute, 0, 12);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 20);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 6);
		validator.CollectionSize(x => x.CustomsInformation, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN7, 1, 255);
		validator.CollectionSize(x => x.LN1, 0, 10);
		validator.CollectionSize(x => x.LS1, 0, 6);
		validator.CollectionSize(x => x.LLX, 1, 25);
		validator.CollectionSize(x => x.LT1, 0, 64);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LS1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LT1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
