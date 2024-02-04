using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._222;

public class L2000_L2200 {
	[SectionPosition(1)] public S5_StopOffDetails StopOffDetails { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(4)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(5)] public List<PLD_PalletInformation> PalletInformation { get; set; } = new();
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(7)] public List<L2000__L2200_L2210> L2210 {get;set;} = new();
	[SectionPosition(8)] public List<L2000__L2200_L2400> L2400 {get;set;} = new();
	[SectionPosition(9)] public List<L2000__L2200_L2600> L2600 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2200>(this);
		validator.Required(x => x.StopOffDetails);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 6);
		validator.CollectionSize(x => x.PalletInformation, 0, 2);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.L2400, 0, 99);
		validator.CollectionSize(x => x.L2600, 0, 25);
		foreach (var item in L2210) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2400) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2600) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
