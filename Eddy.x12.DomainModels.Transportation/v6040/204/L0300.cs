using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._204;

public class L0300 {
	[SectionPosition(1)] public S5_StopOffDetails StopOffDetails { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(4)] public AT8_ShipmentWeightPackagingAndQuantityData? ShipmentWeightPackagingAndQuantityData { get; set; }
	[SectionPosition(5)] public List<LAD_LadingDetail> LadingDetail { get; set; } = new();
	[SectionPosition(6)] public List<L0300_L0305> L0305 {get;set;} = new();
	[SectionPosition(7)] public PLD_PalletShipmentInformation? PalletShipmentInformation { get; set; }
	[SectionPosition(8)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(9)] public List<L0300_L0310> L0310 {get;set;} = new();
	[SectionPosition(10)] public List<L0300_L0320> L0320 {get;set;} = new();
	[SectionPosition(11)] public List<L0300_L0350> L0350 {get;set;} = new();
	[SectionPosition(12)] public List<L0300_L0380> L0380 {get;set;} = new();
}
