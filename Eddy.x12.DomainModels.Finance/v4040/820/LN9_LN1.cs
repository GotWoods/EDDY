using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._820;

public class LN9_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<LN9__LN1_LEMS> LEMS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.LEMS, 1, 2147483647);
		foreach (var item in LEMS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
