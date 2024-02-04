using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._358;

public class LP4 {
	[SectionPosition(1)] public P4_USPortInformation USPortInformation { get; set; } = new();
	[SectionPosition(2)] public List<VID_ConveyanceIdentification> ConveyanceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<LP4_LMBL> LMBL {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.USPortInformation);
		validator.CollectionSize(x => x.ConveyanceIdentification, 0, 500);
		validator.CollectionSize(x => x.LMBL, 1, 9999);
		foreach (var item in LMBL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
