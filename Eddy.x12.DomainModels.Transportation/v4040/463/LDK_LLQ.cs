using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._463;

public class LDK_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDK_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		return validator.Results;
	}
}
