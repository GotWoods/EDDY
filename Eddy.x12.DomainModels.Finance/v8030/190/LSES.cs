using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._190;

public class LSES {
	[SectionPosition(1)] public SES_AcademicSessionHeader AcademicSessionHeader { get; set; } = new();
	[SectionPosition(2)] public List<SUM_AcademicSummary> AcademicSummary { get; set; } = new();
	[SectionPosition(3)] public ENR_SchoolEnrollmentInformation? SchoolEnrollmentInformation { get; set; }
	[SectionPosition(4)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	[SectionPosition(5)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSES>(this);
		validator.Required(x => x.AcademicSessionHeader);
		validator.CollectionSize(x => x.AcademicSummary, 0, 6);
		validator.CollectionSize(x => x.FieldOfStudy, 0, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		return validator.Results;
	}
}
