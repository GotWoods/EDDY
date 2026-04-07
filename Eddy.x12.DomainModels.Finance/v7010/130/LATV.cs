using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._130;

public class LATV {
	[SectionPosition(1)] public ATV_StudentActivitiesAndAwards StudentActivitiesAndAwards { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LATV>(this);
		validator.Required(x => x.StudentActivitiesAndAwards);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		return validator.Results;
	}
}
