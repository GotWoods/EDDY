using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Transportation.v3020._410;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi410_RailCarrierFreightDetailsAndInvoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B3B_BeginningSegmentForCarriersInvoice BeginningSegmentForCarriersInvoice { get; set; } = new();
	[SectionPosition(3)] public C4_AlternateAmountDue? AlternateAmountDue { get; set; }
	[SectionPosition(4)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public List<LN7> LN7 {get;set;} = new();
	[SectionPosition(6)] public List<N8_WaybillReference> WaybillReference { get; set; } = new();
	[SectionPosition(7)] public F9_OriginStation OriginStation { get; set; } = new();
	[SectionPosition(8)] public D9_DestinationStation DestinationStation { get; set; } = new();
	[SectionPosition(9)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(10)] public F1_ConsignorName? ConsignorName { get; set; }
	[SectionPosition(11)] public List<F2_ConsignorAddress> ConsignorAddress { get; set; } = new();
	[SectionPosition(12)] public F4_ConsignorCity? ConsignorCity { get; set; }
	[SectionPosition(13)] public D1_ConsigneeName? ConsigneeName { get; set; }
	[SectionPosition(14)] public List<D2_ConsigneeAddress> ConsigneeAddress { get; set; } = new();
	[SectionPosition(15)] public D4_ConsigneeCity? ConsigneeCity { get; set; }
	[SectionPosition(16)] public U1_UltimateConsigneeName? UltimateConsigneeName { get; set; }
	[SectionPosition(17)] public U2_UltimateConsigneeAddress? UltimateConsigneeAddress { get; set; }
	[SectionPosition(18)] public U4_UltimateConsigneeCity? UltimateConsigneeCity { get; set; }
	[SectionPosition(19)] public U5_PriorOriginName? PriorOriginName { get; set; }
	[SectionPosition(20)] public U6_PriorOriginAddress? PriorOriginAddress { get; set; }
	[SectionPosition(21)] public U9_PriorOriginCity? PriorOriginCity { get; set; }
	[SectionPosition(22)] public List<LF5> LF5 {get;set;} = new();
	[SectionPosition(23)] public List<LD5> LD5 {get;set;} = new();
	[SectionPosition(24)] public List<LS1> LS1 {get;set;} = new();
	[SectionPosition(25)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(26)] public RE_RebillAtInterchange? RebillAtInterchange { get; set; }
	[SectionPosition(27)] public List<PS_ProtectiveServiceInstructions> ProtectiveServiceInstructions { get; set; } = new();
	[SectionPosition(28)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(29)] public List<LT1> LT1 {get;set;} = new();
	[SectionPosition(30)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(31)] public List<X7_CustomsInformation> CustomsInformation { get; set; } = new();
	[SectionPosition(32)] public GA_CanadianGrainInformation? CanadianGrainInformation { get; set; }
	[SectionPosition(33)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi410_RailCarrierFreightDetailsAndInvoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarriersInvoice);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 30);
		validator.CollectionSize(x => x.WaybillReference, 1, 255);
		validator.Required(x => x.OriginStation);
		validator.Required(x => x.DestinationStation);
		validator.CollectionSize(x => x.ConsignorAddress, 0, 2);
		validator.CollectionSize(x => x.ConsigneeAddress, 0, 2);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.ProtectiveServiceInstructions, 0, 3);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.CollectionSize(x => x.CustomsInformation, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN7, 1, 255);
		validator.CollectionSize(x => x.LN1, 0, 10);
		validator.CollectionSize(x => x.LF5, 0, 10);
		validator.CollectionSize(x => x.LD5, 0, 10);
		validator.CollectionSize(x => x.LS1, 0, 6);
		validator.CollectionSize(x => x.LLX, 1, 25);
		validator.CollectionSize(x => x.LT1, 0, 64);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LF5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LD5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LS1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LT1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
