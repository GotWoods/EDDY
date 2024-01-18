using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;
using Eddy.x12.DomainModels.Transportation.v4040._204;

namespace Eddy.x12.DomainModels.Transportation.v4040;

public class Edi204_MotorCarrierLoadTender {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2_BeginningSegmentForShipmentInformationTransaction BeginningSegmentForShipmentInformationTransaction { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(4)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public G62_DateTime? DateTime { get; set; }
	[SectionPosition(6)] public MS3_InterlineInformation? InterlineInformation { get; set; }
	[SectionPosition(7)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(8)] public PLD_PalletInformation? PalletInformation { get; set; }
	[SectionPosition(9)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(10)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(11)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(12)] public List<L0200> L0200 {get;set;} = new();

	//Details
	[SectionPosition(13)] public List<L0300> L0300 {get;set;} = new();

	//Summary
	[SectionPosition(14)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(15)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

}
