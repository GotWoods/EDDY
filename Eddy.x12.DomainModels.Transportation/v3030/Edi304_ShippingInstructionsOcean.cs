using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._304;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi304_ShippingInstructionsOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2_BeginningSegmentForShipmentInformationTransaction BeginningSegmentForShipmentInformationTransaction { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose? SetPurpose { get; set; }
	[SectionPosition(4)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(5)] public G1_ShipmentTypeInformation? ShipmentTypeInformation { get; set; }
	[SectionPosition(6)] public G2_BeyondRouting? BeyondRouting { get; set; }
	[SectionPosition(7)] public G3_CompensationInformation? CompensationInformation { get; set; }
	[SectionPosition(8)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(9)] public List<V1_VesselIdentification> VesselIdentification { get; set; } = new();
	[SectionPosition(10)] public V3_VesselSchedule? VesselSchedule { get; set; }
	[SectionPosition(11)] public M0_LetterOfCreditReference? LetterOfCreditReference { get; set; }
	[SectionPosition(12)] public List<M1_Insurance> Insurance { get; set; } = new();
	[SectionPosition(13)] public M2_SalesDeliveryTerms? SalesDeliveryTerms { get; set; }
	[SectionPosition(14)] public C2_BankID? BankID { get; set; }
	[SectionPosition(15)] public C3_Currency? Currency { get; set; }
	[SectionPosition(16)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(17)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(18)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(19)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(20)] public List<L11_BusinessInstructions> BusinessInstructions { get; set; } = new();
	[SectionPosition(21)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(22)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();

	//Details
	[SectionPosition(23)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(24)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(25)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(26)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(27)] public List<LL1> LL1 {get;set;} = new();
	[SectionPosition(28)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(29)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(30)] public List<L11_BusinessInstructions> BusinessInstructions { get; set; } = new();
	[SectionPosition(31)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi304_ShippingInstructionsOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentInformationTransaction);
		validator.CollectionSize(x => x.Authentication, 0, 2);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 100);
		validator.CollectionSize(x => x.VesselIdentification, 0, 2);
		validator.CollectionSize(x => x.Insurance, 0, 5);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.Remarks, 0, 12);
		validator.CollectionSize(x => x.BusinessInstructions, 0, 99);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 999);
		

		validator.CollectionSize(x => x.LN1, 1, 10);
		validator.CollectionSize(x => x.LR4, 1, 20);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLX, 1, 999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.CollectionSize(x => x.Measurements, 0, 5);
		validator.CollectionSize(x => x.Paperwork, 0, 25);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		validator.CollectionSize(x => x.Remarks, 0, 999);
		validator.CollectionSize(x => x.BusinessInstructions, 0, 24);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LL1, 0, 20);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
