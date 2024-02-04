using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;
using Eddy.x12.DomainModels.Transportation.v7020._304;

namespace Eddy.x12.DomainModels.Transportation.v7020;

public class Edi304_ShippingInstructions {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2_BeginningSegmentForShipmentInformationTransaction BeginningSegmentForShipmentInformationTransaction { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose? SetPurpose { get; set; }
	[SectionPosition(4)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(5)] public G1_ShipmentTypeInformation? ShipmentTypeInformation { get; set; }
	[SectionPosition(6)] public G2_BeyondRouting? BeyondRouting { get; set; }
	[SectionPosition(7)] public G3_CompensationInformation? CompensationInformation { get; set; }
	[SectionPosition(8)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(9)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(10)] public List<V1_VesselIdentification> VesselIdentification { get; set; } = new();
	[SectionPosition(11)] public V3_VesselSchedule? VesselSchedule { get; set; }
	[SectionPosition(12)] public M0_LetterOfCreditReference? LetterOfCreditReference { get; set; }
	[SectionPosition(13)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(14)] public List<LM1> LM1 {get;set;} = new();
	[SectionPosition(15)] public M2_SalesDeliveryTerms? SalesDeliveryTerms { get; set; }
	[SectionPosition(16)] public C2_BankID? BankID { get; set; }
	[SectionPosition(17)] public ITD_TermsOfSaleDeferredTermsOfSale? TermsOfSaleDeferredTermsOfSale { get; set; }
	[SectionPosition(18)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(19)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(20)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(21)] public List<R2A_RouteInformationWithPreference> RouteInformationWithPreference { get; set; } = new();
	[SectionPosition(22)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(23)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(24)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(25)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(26)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(27)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	[SectionPosition(28)] public List<X2_ImportLicense> ImportLicense { get; set; } = new();
	[SectionPosition(29)] public List<LC8> LC8 {get;set;} = new();

	//Details
	[SectionPosition(30)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(31)] public List<LL3> LL3 {get;set;} = new();
	[SectionPosition(32)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi304_ShippingInstructions>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentInformationTransaction);
		validator.CollectionSize(x => x.Authentication, 0, 2);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 100);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 10);
		validator.CollectionSize(x => x.VesselIdentification, 0, 2);
		validator.CollectionSize(x => x.DateTimeReference, 0, 20);
		validator.CollectionSize(x => x.RouteInformationWithPreference, 0, 25);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.Remarks, 0, 12);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 99);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 20);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 999);
		validator.CollectionSize(x => x.ExportLicense, 0, 25);
		validator.CollectionSize(x => x.ImportLicense, 0, 5);
		

		validator.CollectionSize(x => x.LM1, 0, 5);
		validator.CollectionSize(x => x.LN1, 0, 100);
		validator.CollectionSize(x => x.LR4, 0, 20);
		validator.CollectionSize(x => x.LC8, 0, 20);
		foreach (var item in LM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LC8) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLX, 0, 999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		foreach (var item in LL3) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
