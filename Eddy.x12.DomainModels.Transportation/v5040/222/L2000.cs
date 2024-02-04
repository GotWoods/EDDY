using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Transportation.v5040._222;

public class L2000 {
	[SectionPosition(1)] public PLC_EquipmentPlacementInformation EquipmentPlacementInformation { get; set; } = new();
	[SectionPosition(2)] public List<N7_EquipmentDetails> EquipmentDetails { get; set; } = new();
	[SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(5)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(6)] public List<L2000_L2100> L2100 {get;set;} = new();
	[SectionPosition(7)] public List<L2000_L2200> L2200 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000>(this);
		validator.Required(x => x.EquipmentPlacementInformation);
		validator.CollectionSize(x => x.EquipmentDetails, 1, 10);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 6);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.L2100, 0, 25);
		validator.CollectionSize(x => x.L2200, 1, 99);
		foreach (var item in L2100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
