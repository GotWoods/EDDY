using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Finance.v5010._132;

public class LHL__LCQ_LCRS {
	[SectionPosition(1)] public CRS_CourseRecord CourseRecord { get; set; } = new();
	[SectionPosition(2)] public CSU_SupplementalCourseData? SupplementalCourseData { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LCQ_LCRS>(this);
		validator.Required(x => x.CourseRecord);
		return validator.Results;
	}
}
