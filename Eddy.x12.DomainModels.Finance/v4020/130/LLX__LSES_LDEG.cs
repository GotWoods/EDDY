using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._130;

public class LLX__LSES_LDEG {
	[SectionPosition(1)] public DEG_DegreeRecord DegreeRecord { get; set; } = new();
	[SectionPosition(2)] public List<SUM_AcademicSummary> AcademicSummary { get; set; } = new();
	[SectionPosition(3)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	[SectionPosition(4)] public N1_Name? Name { get; set; }
	[SectionPosition(5)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LSES_LDEG>(this);
		validator.Required(x => x.DegreeRecord);
		validator.CollectionSize(x => x.AcademicSummary, 0, 5);
		validator.CollectionSize(x => x.FieldOfStudy, 0, 30);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 30);
		return validator.Results;
	}
}
