using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._426;

public class LBNX {
	[SectionPosition(1)] public BNX_RailShipmentInformation RailShipmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<LBNX_LN7> LN7 {get;set;} = new();
	[SectionPosition(5)] public List<N8_WaybillReference> WaybillReference { get; set; } = new();
	[SectionPosition(6)] public V9_EventDetail? EventDetail { get; set; }
	[SectionPosition(7)] public F9_OriginStation OriginStation { get; set; } = new();
	[SectionPosition(8)] public D9_DestinationStation DestinationStation { get; set; } = new();
	[SectionPosition(9)] public List<LBNX_LN1> LN1 {get;set;} = new();
	[SectionPosition(10)] public List<LBNX_LS1> LS1 {get;set;} = new();
	[SectionPosition(11)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(12)] public RE_RebillAtInterchange? RebillAtInterchange { get; set; }
	[SectionPosition(13)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(14)] public List<PS_ProtectiveServiceInstructions> ProtectiveServiceInstructions { get; set; } = new();
	[SectionPosition(15)] public List<LBNX_LLX> LLX {get;set;} = new();
	[SectionPosition(16)] public List<LBNX_LT1> LT1 {get;set;} = new();
	[SectionPosition(17)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(18)] public List<PRI_ExternalReferenceIdentifier> ExternalReferenceIdentifier { get; set; } = new();
	[SectionPosition(19)] public List<L7A_ContractReferenceIdentifier> ContractReferenceIdentifier { get; set; } = new();
	[SectionPosition(20)] public List<LBNX_LR2B> LR2B {get;set;} = new();
	[SectionPosition(21)] public List<X7_CustomsInformation> CustomsInformation { get; set; } = new();
	[SectionPosition(22)] public GA_CanadianGrainInformation? CanadianGrainInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBNX>(this);
		validator.Required(x => x.RailShipmentInformation);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 30);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.CollectionSize(x => x.WaybillReference, 1, 255);
		validator.Required(x => x.OriginStation);
		validator.Required(x => x.DestinationStation);
		validator.CollectionSize(x => x.RouteInformation, 1, 13);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.ProtectiveServiceInstructions, 0, 5);
		validator.CollectionSize(x => x.ExternalReferenceIdentifier, 0, 12);
		validator.CollectionSize(x => x.ContractReferenceIdentifier, 0, 12);
		validator.CollectionSize(x => x.CustomsInformation, 0, 10);
		validator.CollectionSize(x => x.LN7, 1, 255);
		validator.CollectionSize(x => x.LN1, 1, 10);
		validator.CollectionSize(x => x.LS1, 0, 6);
		validator.CollectionSize(x => x.LLX, 0, 25);
		validator.CollectionSize(x => x.LT1, 0, 64);
		validator.CollectionSize(x => x.LR2B, 0, 15);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LS1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LT1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LR2B) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
