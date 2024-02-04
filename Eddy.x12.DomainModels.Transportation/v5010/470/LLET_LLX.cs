using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Transportation.v5010._470;

public class LLET_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLET_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 15);
		return validator.Results;
	}
}
