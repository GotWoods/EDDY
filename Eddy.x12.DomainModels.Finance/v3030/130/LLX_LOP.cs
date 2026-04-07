using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._130;

public class LLX_LOP {
	[SectionPosition(1)] public OP_OtherPrograms OtherPrograms { get; set; } = new();
	[SectionPosition(2)] public List<OPS_OtherProgramSubjectAreaAndEligibility> OtherProgramSubjectAreaAndEligibility { get; set; } = new();
	[SectionPosition(3)] public List<OPX_OtherProgramDatesAndCriteria> OtherProgramDatesAndCriteria { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LOP>(this);
		validator.Required(x => x.OtherPrograms);
		validator.CollectionSize(x => x.OtherProgramSubjectAreaAndEligibility, 0, 10);
		validator.CollectionSize(x => x.OtherProgramDatesAndCriteria, 0, 10);
		return validator.Results;
	}
}
