using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._833;

public class LCRO__LLX__LN1_LEMP {
	[SectionPosition(1)] public EMP_Employer Employer { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public List<LCRO__LLX__LN1__LEMP_LEMS> LEMS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO__LLX__LN1_LEMP>(this);
		validator.Required(x => x.Employer);
		validator.CollectionSize(x => x.LEMS, 0, 10);
		foreach (var item in LEMS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
