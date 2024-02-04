using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._423;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public NTE_NoteSpecialInstruction? NoteSpecialInstruction { get; set; }
	[SectionPosition(3)] public List<XD_PlacementPullData> PlacementPullData { get; set; } = new();
	[SectionPosition(4)] public List<LLX_LN7> LN7 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.PlacementPullData, 1, 10);
		validator.CollectionSize(x => x.LN7, 1, 150);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
