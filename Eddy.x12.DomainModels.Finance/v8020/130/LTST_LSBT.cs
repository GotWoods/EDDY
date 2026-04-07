using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._130;

public class LTST_LSBT {
	[SectionPosition(1)] public SBT_Subtest Subtest { get; set; } = new();
	[SectionPosition(2)] public List<SRE_TestScores> TestScores { get; set; } = new();
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTST_LSBT>(this);
		validator.Required(x => x.Subtest);
		validator.CollectionSize(x => x.TestScores, 0, 3);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 2);
		return validator.Results;
	}
}
