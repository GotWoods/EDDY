using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._820;

public class L7000 {
	[SectionPosition(1)] public RYL_RoyaltyPayment RoyaltyPayment { get; set; } = new();
	[SectionPosition(2)] public List<L7000_L7100> L7100 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L7000>(this);
		validator.Required(x => x.RoyaltyPayment);
		validator.CollectionSize(x => x.L7100, 1, 2147483647);
		foreach (var item in L7100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
