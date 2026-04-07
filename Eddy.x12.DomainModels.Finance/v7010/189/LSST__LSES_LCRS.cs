using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._189;

public class LSST__LSES_LCRS {
	[SectionPosition(1)] public CRS_CourseRecord CourseRecord { get; set; } = new();
	[SectionPosition(2)] public NTE_NoteSpecialInstruction? NoteSpecialInstruction { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSST__LSES_LCRS>(this);
		validator.Required(x => x.CourseRecord);
		return validator.Results;
	}
}
