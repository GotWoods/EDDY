using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Transportation.v5020._463;

public class LDK_LLQ {
	[SectionPosition(1)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDK_LLQ>(this);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		return validator.Results;
	}
}
