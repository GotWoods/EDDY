using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._133;

public class LHL_LFOS {
	[SectionPosition(1)] public FOS_FieldOfStudy FieldOfStudy { get; set; } = new();
	[SectionPosition(2)] public DEG_DegreeRecord? DegreeRecord { get; set; }
	[SectionPosition(3)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LFOS>(this);
		validator.Required(x => x.FieldOfStudy);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		return validator.Results;
	}
}
