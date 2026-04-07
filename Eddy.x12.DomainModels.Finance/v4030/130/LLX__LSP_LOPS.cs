using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._130;

public class LLX__LSP_LOPS {
	[SectionPosition(1)] public OPS_ProgramSubjectAreaAndEligibility ProgramSubjectAreaAndEligibility { get; set; } = new();
	[SectionPosition(2)] public List<OPX_PlacementCriteria> PlacementCriteria { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LSP_LOPS>(this);
		validator.Required(x => x.ProgramSubjectAreaAndEligibility);
		validator.CollectionSize(x => x.PlacementCriteria, 0, 2);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 10);
		return validator.Results;
	}
}
