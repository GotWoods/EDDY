using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._132;

public class LHL__LEMS_LSES {
	[SectionPosition(1)] public SES_AcademicSessionHeader AcademicSessionHeader { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public List<LHL__LEMS__LSES_LWLD> LWLD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LEMS_LSES>(this);
		validator.Required(x => x.AcademicSessionHeader);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.LWLD, 1, 2147483647);
		foreach (var item in LWLD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
