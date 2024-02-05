using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._218;

public class L2400_L2410 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<L2400__L2410_L2420> L2420 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2400_L2410>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.Geography, 0, 99);
		validator.CollectionSize(x => x.L2420, 0, 9999);
		foreach (var item in L2420) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
