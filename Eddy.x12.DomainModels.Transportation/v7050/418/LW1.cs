using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._418;

public class LW1 {
	[SectionPosition(1)] public W1_BlockIdentification BlockIdentification { get; set; } = new();
	[SectionPosition(2)] public List<LW1_LW2> LW2 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LW1>(this);
		validator.Required(x => x.BlockIdentification);
		validator.CollectionSize(x => x.LW2, 1, 800);
		foreach (var item in LW2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
