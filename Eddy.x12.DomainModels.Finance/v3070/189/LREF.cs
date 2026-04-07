using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._189;

public class LREF {
	[SectionPosition(1)] public REF_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public N1_Name? Name { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LREF>(this);
		validator.Required(x => x.ReferenceIdentification);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		return validator.Results;
	}
}
