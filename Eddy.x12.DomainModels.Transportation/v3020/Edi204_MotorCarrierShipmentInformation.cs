using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Transportation.v3020._204;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi204_MotorCarrierShipmentInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2_BeginningSegmentForShipmentInformationTransaction BeginningSegmentForShipmentInformationTransaction { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose? SetPurpose { get; set; }
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
	[SectionPosition(15)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(16)] public List<LN7> LN7 {get;set;} = new();

	//Details
	[SectionPosition(17)] public List<LS5> LS5 {get;set;} = new();
	[SectionPosition(18)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(19)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(20)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi204_MotorCarrierShipmentInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentInformationTransaction);
		validator.CollectionSize(x => x.Authentication, 0, 4);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.DateTime, 0, 6);
		validator.CollectionSize(x => x.RouteInformationMotor, 0, 12);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.SpecialServices, 0, 6);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		

		validator.CollectionSize(x => x.LN1, 0, 10);
		validator.CollectionSize(x => x.LN7, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LS5, 0, 999);
		validator.CollectionSize(x => x.LLX, 0, 999);
		foreach (var item in LS5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
