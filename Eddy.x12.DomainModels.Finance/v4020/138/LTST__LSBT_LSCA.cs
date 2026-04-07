using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._138;

public class LTST__LSBT_LSCA {
	[SectionPosition(1)] public SCA_StatisticalCategoryAnalysis StatisticalCategoryAnalysis { get; set; } = new();
	[SectionPosition(2)] public FOS_FieldOfStudy? FieldOfStudy { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTST__LSBT_LSCA>(this);
		validator.Required(x => x.StatisticalCategoryAnalysis);
		return validator.Results;
	}
}
