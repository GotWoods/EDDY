using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._309;

public class LP4 {
	[SectionPosition(1)] public P4_PortInformation PortInformation { get; set; } = new();
	[SectionPosition(2)] public List<LP4_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.PortInformation);
		validator.CollectionSize(x => x.LLX, 1, 9999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
