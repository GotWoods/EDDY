using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._357;

public class LP4 {
	[SectionPosition(1)] public P4_USPortInformation USPortInformation { get; set; } = new();
	[SectionPosition(2)] public List<LP4_LM21> LM21 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.USPortInformation);
		validator.CollectionSize(x => x.LM21, 1, 999);
		foreach (var item in LM21) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
