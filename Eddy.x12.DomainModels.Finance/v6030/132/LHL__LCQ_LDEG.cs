using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._132;

public class LHL__LCQ_LDEG {
	[SectionPosition(1)] public DEG_DegreeRecord DegreeRecord { get; set; } = new();
	[SectionPosition(2)] public List<FOS_FieldOfStudy> FieldOfStudy { get; set; } = new();
	[SectionPosition(3)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LCQ_LDEG>(this);
		validator.Required(x => x.DegreeRecord);
		validator.CollectionSize(x => x.FieldOfStudy, 0, 10);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		return validator.Results;
	}
}
