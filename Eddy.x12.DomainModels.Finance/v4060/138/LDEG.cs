using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._138;

public class LDEG {
	[SectionPosition(1)] public DEG_DegreeRecord DegreeRecord { get; set; } = new();
	[SectionPosition(2)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEG>(this);
		validator.Required(x => x.DegreeRecord);
		validator.CollectionSize(x => x.FieldOfStudy, 0, 5);
		return validator.Results;
	}
}
