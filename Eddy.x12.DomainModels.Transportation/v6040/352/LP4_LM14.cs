using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._352;

public class LP4_LM14 {
	[SectionPosition(1)] public M14_GeneralOrderStatusInformation GeneralOrderStatusInformation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LM14>(this);
		validator.Required(x => x.GeneralOrderStatusInformation);
		validator.CollectionSize(x => x.Remarks, 0, 4);
		return validator.Results;
	}
}
