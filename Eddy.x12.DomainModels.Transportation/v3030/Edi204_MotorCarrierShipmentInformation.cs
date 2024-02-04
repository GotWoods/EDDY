using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._204;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi204_MotorCarrierShipmentInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2_BeginningSegmentForShipmentInformationTransaction BeginningSegmentForShipmentInformationTransaction { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(4)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(5)] public C2_BankID? BankID { get; set; }
	[SectionPosition(6)] public C3_Currency? Currency { get; set; }
	[SectionPosition(7)] public ITD_TermsOfSaleDeferredTermsOfSale? TermsOfSaleDeferredTermsOfSale { get; set; }
	[SectionPosition(8)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(9)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(10)] public List<R3_RouteInformationMotor> RouteInformationMotor { get; set; } = new();
	[SectionPosition(11)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(12)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(13)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(14)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(15)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(16)] public List<L0200> L0200 {get;set;} = new();

	//Details
	[SectionPosition(17)] public List<L0300> L0300 {get;set;} = new();
	[SectionPosition(18)] public List<L0400> L0400 {get;set;} = new();

	//Summary
	[SectionPosition(19)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(20)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi204_MotorCarrierShipmentInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentInformationTransaction);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.Authentication, 0, 4);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.DateTime, 0, 6);
		validator.CollectionSize(x => x.RouteInformationMotor, 0, 12);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.SpecialServices, 0, 6);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		validator.CollectionSize(x => x.L0200, 0, 10);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L0300, 0, 999);
		validator.CollectionSize(x => x.L0400, 0, 999);
		foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0400) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
