using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._189;

public class LPCL_LSES {
	[SectionPosition(1)] public SES_AcademicSessionHeader AcademicSessionHeader { get; set; } = new();
	[SectionPosition(2)] public List<LPCL__LSES_LCRS> LCRS {get;set;} = new();
	[SectionPosition(3)] public List<LPCL__LSES_LDEG> LDEG {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPCL_LSES>(this);
		validator.Required(x => x.AcademicSessionHeader);
		validator.CollectionSize(x => x.LCRS, 0, 50);
		validator.CollectionSize(x => x.LDEG, 0, 10);
		foreach (var item in LCRS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDEG) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
