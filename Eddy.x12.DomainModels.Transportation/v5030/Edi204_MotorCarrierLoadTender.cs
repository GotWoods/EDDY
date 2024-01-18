using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;
using Eddy.x12.DomainModels.Transportation.v5030._204;

namespace Eddy.x12.DomainModels.Transportation.v5030;

public class Edi204_MotorCarrierLoadTender {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2_BeginningSegmentForShipmentInformationTransaction BeginningSegmentForShipmentInformationTransaction { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(4)] public C3_CurrencyIdentifier? CurrencyIdentifier { get; set; }
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public G62_DateTime? DateTime { get; set; }
	[SectionPosition(7)] public MS3_InterlineInformation? InterlineInformation { get; set; }
	[SectionPosition(8)] public List<L0050> L0050 {get;set;} = new();
	[SectionPosition(9)] public PLD_PalletShipmentInformation? PalletShipmentInformation { get; set; }
	[SectionPosition(10)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(11)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(12)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(13)] public List<L0200> L0200 {get;set;} = new();

	//Details
	[SectionPosition(14)] public List<L0300> L0300 {get;set;} = new();

	//Summary
	[SectionPosition(15)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(16)] public List<L1000> L1000 {get;set;} = new();
	[SectionPosition(17)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

}
