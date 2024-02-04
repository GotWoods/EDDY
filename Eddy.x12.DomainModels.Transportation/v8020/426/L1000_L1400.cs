using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020._426;

public class L1000_L1400 {
	[SectionPosition(1)] public R2_RouteInformation RouteInformation { get; set; } = new();
	[SectionPosition(2)] public List<L1000__L1400_L1410> L1410 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000_L1400>(this);
		validator.Required(x => x.RouteInformation);
		validator.CollectionSize(x => x.L1410, 0, 4);
		foreach (var item in L1410) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
