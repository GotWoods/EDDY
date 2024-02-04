using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._350;

public class LP4_LVID {
	[SectionPosition(1)] public VID_ConveyanceIdentification ConveyanceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(3)] public List<M7A_SealNumberReplacement> SealNumberReplacement { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LVID>(this);
		validator.Required(x => x.ConveyanceIdentification);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.SealNumberReplacement, 0, 22);
		return validator.Results;
	}
}
