using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._222;

public class L2000__L2200_L2400 {
	[SectionPosition(1)] public LAD_LadingDetail LadingDetail { get; set; } = new();
	[SectionPosition(2)] public List<L2000__L2200__L2400_L2410> L2410 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2200_L2400>(this);
		validator.Required(x => x.LadingDetail);
		foreach (var item in L2410) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
