using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Transportation.v5010._204;

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
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300>(this);
		validator.Required(x => x.StopOffDetails);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 99999);
		validator.CollectionSize(x => x.DateTime, 0, 3);
		validator.CollectionSize(x => x.LadingDetail, 0, 99999);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 20);
		validator.CollectionSize(x => x.L0305, 0, 6);
		validator.CollectionSize(x => x.L0320, 0, 99999);
		validator.CollectionSize(x => x.L0350, 0, 99999);
		validator.CollectionSize(x => x.L0380, 0, 10);
		foreach (var item in L0305) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0310) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0320) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0350) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0380) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
