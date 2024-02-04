using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._358;

public class LP4_LVID {
	[SectionPosition(1)] public VID_ConveyanceIdentification ConveyanceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<LP4__LVID_LMBL> LMBL {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LVID>(this);
		validator.Required(x => x.ConveyanceIdentification);
		validator.CollectionSize(x => x.LMBL, 0, 9999);
		foreach (var item in LMBL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
