using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._245;

public class LHL_LTDT {
	[SectionPosition(1)] public TDT_TaxDelinquencyStatus TaxDelinquencyStatus { get; set; } = new();
	[SectionPosition(2)] public List<LHL__LTDT_LREF> LREF {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LTDT>(this);
		validator.Required(x => x.TaxDelinquencyStatus);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
