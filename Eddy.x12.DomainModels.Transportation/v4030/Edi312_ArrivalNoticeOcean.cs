using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;
using Eddy.x12.DomainModels.Transportation.v4030._312;

namespace Eddy.x12.DomainModels.Transportation.v4030;

public class Edi312_ArrivalNoticeOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B3_BeginningSegmentForCarriersInvoice BeginningSegmentForCarriersInvoice { get; set; } = new();
	[SectionPosition(3)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(4)] public Q3_ArrivalDetails ArrivalDetails { get; set; } = new();
	[SectionPosition(5)] public C3_Currency? Currency { get; set; }
	[SectionPosition(6)] public G1_ShipmentTypeInformation? ShipmentTypeInformation { get; set; }
	[SectionPosition(7)] public G2_BeyondRouting? BeyondRouting { get; set; }
	[SectionPosition(8)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(9)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(10)] public List<V1_VesselIdentification> VesselIdentification { get; set; } = new();
	[SectionPosition(11)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(12)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(13)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(14)] public L5_DescriptionMarksAndNumbers? DescriptionMarksAndNumbers { get; set; }

	//Details
	[SectionPosition(15)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(16)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(17)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(18)] public List<LL1> LL1 {get;set;} = new();
	[SectionPosition(19)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(20)] public L11_BusinessInstructionsAndReferenceNumber? BusinessInstructionsAndReferenceNumber { get; set; }
	[SectionPosition(21)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi312_ArrivalNoticeOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarriersInvoice);
		validator.CollectionSize(x => x.Authentication, 0, 2);
		validator.Required(x => x.ArrivalDetails);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 15);
		validator.CollectionSize(x => x.VesselIdentification, 1, 2);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		

		validator.CollectionSize(x => x.LN1, 1, 10);
		validator.CollectionSize(x => x.LR4, 1, 20);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLX, 1, 999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.CollectionSize(x => x.Remarks, 0, 999);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LL1, 0, 20);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
