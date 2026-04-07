using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Finance.v5010._820;

public class LRYL {
	[SectionPosition(1)] public RYL_RoyaltyPayment RoyaltyPayment { get; set; } = new();
	[SectionPosition(2)] public List<LRYL_LNM1> LNM1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRYL>(this);
		validator.Required(x => x.RoyaltyPayment);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
