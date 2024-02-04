using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._301;

public class LY4 {
	[SectionPosition(1)] public Y4_ContainerRelease ContainerRelease { get; set; } = new();
	[SectionPosition(2)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LY4>(this);
		validator.Required(x => x.ContainerRelease);
		return validator.Results;
	}
}
