using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._198;

public class LIN1_LAPI {
	[SectionPosition(1)] public API_ActivityOrProcessInformation ActivityOrProcessInformation { get; set; } = new();
	[SectionPosition(2)] public List<LIN1__LAPI_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1_LAPI>(this);
		validator.Required(x => x.ActivityOrProcessInformation);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
