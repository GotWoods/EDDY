using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._358;

public class LP4_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public VID_ConveyanceIdentification? ConveyanceIdentification { get; set; }
	[SectionPosition(3)] public List<LP4__LLX_LMBL> LMBL {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.LMBL, 1, 9999);
		foreach (var item in LMBL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
