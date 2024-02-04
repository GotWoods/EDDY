using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._417;

public class LN7_LREF {
	[SectionPosition(1)] public REF_ReferenceIdentification ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<N10_QuantityAndDescription> QuantityAndDescription { get; set; } = new();
	[SectionPosition(3)] public List<LN7__LREF_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7_LREF>(this);
		validator.Required(x => x.ReferenceInformation);
		validator.CollectionSize(x => x.QuantityAndDescription, 0, 15);
		validator.CollectionSize(x => x.LN1, 0, 5);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
