using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._820;

public class LN9 {
	[SectionPosition(1)] public N9_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<LN9_LAMT> LAMT {get;set;} = new();
	[SectionPosition(3)] public List<LN9_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9>(this);
		validator.Required(x => x.ReferenceIdentification);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
