using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._811;

public class LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<LN1_LBAL> LBAL {get;set;} = new();
	[SectionPosition(3)] public List<LN1_LITA> LITA {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.LBAL, 1, 2147483647);
		validator.CollectionSize(x => x.LITA, 1, 2147483647);
		foreach (var item in LBAL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LITA) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
