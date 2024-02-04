using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.Transportation.v3010._859;

public class LLX_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public List<LLX__LLX_LL0> LL0 {get;set;} = new();
	[SectionPosition(4)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 10);
		validator.CollectionSize(x => x.TariffReference, 0, 10);
		validator.CollectionSize(x => x.LL0, 0, 10);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
