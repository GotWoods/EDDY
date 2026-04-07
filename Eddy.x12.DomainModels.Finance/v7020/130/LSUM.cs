using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._130;

public class LSUM {
	[SectionPosition(1)] public SUM_AcademicSummary AcademicSummary { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSUM>(this);
		validator.Required(x => x.AcademicSummary);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 50);
		return validator.Results;
	}
}
