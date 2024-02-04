using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._453;

public class LSR {
	[SectionPosition(1)] public SR_RequestedServiceSchedule RequestedServiceSchedule { get; set; } = new();
	[SectionPosition(2)] public List<LSR_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSR>(this);
		validator.Required(x => x.RequestedServiceSchedule);
		validator.CollectionSize(x => x.LLX, 0, 999999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
