using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._194;

public class LHL__LLX_LDEG {
	[SectionPosition(1)] public DEG_DegreeRecord DegreeRecord { get; set; } = new();
	[SectionPosition(2)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	[SectionPosition(3)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LLX_LDEG>(this);
		validator.Required(x => x.DegreeRecord);
		validator.CollectionSize(x => x.FieldOfStudy, 1, 2147483647);
		validator.CollectionSize(x => x.PartyIdentification, 1, 2147483647);
		return validator.Results;
	}
}
