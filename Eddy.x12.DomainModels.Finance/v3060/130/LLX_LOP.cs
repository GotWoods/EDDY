using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._130;

public class LLX_LOP {
	[SectionPosition(1)] public OP_OtherProgramsAndServices OtherProgramsAndServices { get; set; } = new();
	[SectionPosition(2)] public List<OPS_OtherProgramSubjectAreaAndEligibility> OtherProgramSubjectAreaAndEligibility { get; set; } = new();
	[SectionPosition(3)] public List<OPX_OtherProgramDatesAndCriteria> OtherProgramDatesAndCriteria { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LOP>(this);
		validator.Required(x => x.OtherProgramsAndServices);
		validator.CollectionSize(x => x.OtherProgramSubjectAreaAndEligibility, 0, 10);
		validator.CollectionSize(x => x.OtherProgramDatesAndCriteria, 0, 10);
		return validator.Results;
	}
}
