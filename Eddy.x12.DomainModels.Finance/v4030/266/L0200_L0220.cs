using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._266;

public class L0200_L0220 {
	[SectionPosition(1)] public N9_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<L0200__L0220_L0221> L0221 {get;set;} = new();
	[SectionPosition(3)] public List<L0200__L0220_L0222> L0222 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0220>(this);
		validator.Required(x => x.ReferenceIdentification);
		validator.CollectionSize(x => x.L0221, 1, 2147483647);
		validator.CollectionSize(x => x.L0222, 1, 2147483647);
		foreach (var item in L0221) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0222) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
