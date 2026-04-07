using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._133;

public class LHL_LATV {
	[SectionPosition(1)] public ATV_StudentActivitiesAndAwards StudentActivitiesAndAwards { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LATV>(this);
		validator.Required(x => x.StudentActivitiesAndAwards);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		return validator.Results;
	}
}
