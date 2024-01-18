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

}
