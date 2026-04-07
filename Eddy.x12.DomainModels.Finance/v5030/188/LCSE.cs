using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._188;

public class LCSE {
	[SectionPosition(1)] public CSE_EducationalCourseInformation EducationalCourseInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public List<CSU_SupplementalCourseData> SupplementalCourseData { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCSE>(this);
		validator.Required(x => x.EducationalCourseInformation);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 10);
		validator.CollectionSize(x => x.SupplementalCourseData, 0, 10);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		return validator.Results;
	}
}
