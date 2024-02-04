using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;
using Eddy.x12.DomainModels.Transportation.v4050._310;

namespace Eddy.x12.DomainModels.Transportation.v4050;

public class Edi310_FreightReceiptAndInvoiceOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B3_BeginningSegmentForCarriersInvoice BeginningSegmentForCarriersInvoice { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose? SetPurpose { get; set; }
	[SectionPosition(4)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(5)] public G3_CompensationInformation? CompensationInformation { get; set; }
	[SectionPosition(6)] public List<N9_ReferenceIdentification> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<V1_VesselIdentification> VesselIdentification { get; set; } = new();
	[SectionPosition(8)] public M0_LetterOfCreditReference? LetterOfCreditReference { get; set; }
	[SectionPosition(9)] public List<M1_Insurance> Insurance { get; set; } = new();
	[SectionPosition(10)] public C2_BankID? BankID { get; set; }
	[SectionPosition(11)] public C3_Currency? Currency { get; set; }
	[SectionPosition(12)] public List<Y2_ContainerDetails> ContainerDetails { get; set; } = new();
	[SectionPosition(13)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(14)] public List<G61_Contact> Contact { get; set; } = new();
	[SectionPosition(15)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(16)] public List<R2A_RouteInformationWithPreference> RouteInformationWithPreference { get; set; } = new();
	[SectionPosition(17)] public List<R2_RouteInformation> RouteInformation { get; set; } = new();
	[SectionPosition(18)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(19)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(20)] public L5_DescriptionMarksAndNumbers? DescriptionMarksAndNumbers { get; set; }
	[SectionPosition(21)] public List<LC8> LC8 {get;set;} = new();

	//Details
	[SectionPosition(22)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(23)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(24)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(25)] public List<LL1> LL1 {get;set;} = new();
	[SectionPosition(26)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(27)] public List<C8_CertificationsAndClauses> CertificationsAndClauses { get; set; } = new();
	[SectionPosition(28)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(29)] public L11_BusinessInstructionsAndReferenceNumber? BusinessInstructionsAndReferenceNumber { get; set; }
	[SectionPosition(30)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi310_FreightReceiptAndInvoiceOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForCarriersInvoice);
		validator.CollectionSize(x => x.Authentication, 0, 2);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 15);
		validator.CollectionSize(x => x.VesselIdentification, 1, 2);
		validator.CollectionSize(x => x.Insurance, 0, 5);
		validator.CollectionSize(x => x.ContainerDetails, 0, 10);
		validator.CollectionSize(x => x.Contact, 0, 3);
		validator.CollectionSize(x => x.RouteInformationWithPreference, 0, 25);
		validator.CollectionSize(x => x.RouteInformation, 0, 13);
		validator.CollectionSize(x => x.Remarks, 0, 12);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		

		validator.CollectionSize(x => x.LN1, 1, 10);
		validator.CollectionSize(x => x.LR4, 1, 20);
		validator.CollectionSize(x => x.LC8, 0, 20);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LC8) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLX, 1, 999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.CollectionSize(x => x.Paperwork, 0, 25);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		validator.CollectionSize(x => x.CertificationsAndClauses, 0, 20);
		validator.CollectionSize(x => x.Remarks, 0, 999);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LL1, 0, 20);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
