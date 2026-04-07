using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._189;

public class LSST_LSES {
	[SectionPosition(1)] public SES_AcademicSessionHeader AcademicSessionHeader { get; set; } = new();
	[SectionPosition(2)] public List<LSST__LSES_LCRS> LCRS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSST_LSES>(this);
		validator.Required(x => x.AcademicSessionHeader);
		validator.CollectionSize(x => x.LCRS, 0, 50);
		foreach (var item in LCRS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
