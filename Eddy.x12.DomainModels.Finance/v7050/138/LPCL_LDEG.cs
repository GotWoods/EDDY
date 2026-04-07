using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Finance.v7050._138;

public class LPCL_LDEG {
	[SectionPosition(1)] public DEG_DegreeRecord DegreeRecord { get; set; } = new();
	[SectionPosition(2)] public SUM_AcademicSummary? AcademicSummary { get; set; }
	[SectionPosition(3)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPCL_LDEG>(this);
		validator.Required(x => x.DegreeRecord);
		validator.CollectionSize(x => x.FieldOfStudy, 0, 30);
		return validator.Results;
	}
}
