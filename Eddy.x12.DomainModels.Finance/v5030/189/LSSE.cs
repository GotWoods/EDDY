using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._189;

public class LSSE {
	[SectionPosition(1)] public SSE_EntryAndExitInformation EntryAndExitInformation { get; set; } = new();
	[SectionPosition(2)] public DEG_DegreeRecord? DegreeRecord { get; set; }
	[SectionPosition(3)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSSE>(this);
		validator.Required(x => x.EntryAndExitInformation);
		validator.CollectionSize(x => x.FieldOfStudy, 0, 5);
		return validator.Results;
	}
}
