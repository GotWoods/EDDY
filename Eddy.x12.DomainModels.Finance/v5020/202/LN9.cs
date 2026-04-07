using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._202;

public class LN9 {
	[SectionPosition(1)] public N9_ExtendedReferenceInformation ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<LN9_LDEX> LDEX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9>(this);
		validator.Required(x => x.ExtendedReferenceInformation);
		validator.CollectionSize(x => x.LDEX, 1, 2147483647);
		foreach (var item in LDEX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
