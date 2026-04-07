using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._138;

public class LATV {
	[SectionPosition(1)] public ATV_StudentActivitiesAndAwards StudentActivitiesAndAwards { get; set; } = new();
	[SectionPosition(2)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	[SectionPosition(3)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LATV>(this);
		validator.Required(x => x.StudentActivitiesAndAwards);
		return validator.Results;
	}
}
