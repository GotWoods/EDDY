using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Transportation.v3060._410;

namespace Eddy.x12.DomainModels.Transportation.v3060;

public class Edi410_RailCarrierFreightDetailsAndInvoice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B3B_BeginningSegmentForCarriersInvoice BeginningSegmentForCarriersInvoice { get; set; } = new();
	[SectionPosition(3)] public C4_AlternateAmountDue? AlternateAmountDue { get; set; }
	[SectionPosition(4)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(5)] public List<LN7> LN7 {get;set;} = new();
	[SectionPosition(6)] public List<N8_WaybillReference> WaybillReference { get; set; } = new();
	[SectionPosition(7)] public F9_OriginStation OriginStation { get; set; } = new();
	[SectionPosition(8)] public D9_DestinationStation DestinationStation { get; set; } = new();
	[SectionPosition(9)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(10)] public List<LS1> LS1 {get;set;} = new();
	[SectionPosition(11)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(12)] public R9_RouteCode? RouteCode { get; set; }
	[SectionPosition(13)] public List<PS_ProtectiveServiceInstructions> ProtectiveServiceInstructions { get; set; } = new();
	[SectionPosition(14)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(15)] public List<LT1> LT1 {get;set;} = new();
	[SectionPosition(16)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(17)] public List<X7_CustomsInformation> CustomsInformation { get; set; } = new();
	[SectionPosition(18)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi410_RailCarrierFreightDetailsAndInvoice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarriersInvoice);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 30);
		validator.CollectionSize(x => x.WaybillReference, 1, 499);
		validator.Required(x => x.OriginStation);
		validator.Required(x => x.DestinationStation);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.ProtectiveServiceInstructions, 0, 5);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.CollectionSize(x => x.CustomsInformation, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN7, 1, 500);
		validator.CollectionSize(x => x.LN1, 0, 10);
		validator.CollectionSize(x => x.LS1, 0, 6);
		validator.CollectionSize(x => x.LLX, 1, 25);
		validator.CollectionSize(x => x.LT1, 0, 64);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LS1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LT1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
