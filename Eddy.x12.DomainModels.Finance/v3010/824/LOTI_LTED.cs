using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.Finance.v3010._824;

public class LOTI_LTED {
	[SectionPosition(1)] public TED_TechnicalErrorDescription TechnicalErrorDescription { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LOTI_LTED>(this);
		validator.Required(x => x.TechnicalErrorDescription);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		return validator.Results;
	}
}
