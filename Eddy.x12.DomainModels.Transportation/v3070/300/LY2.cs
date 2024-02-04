using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._300;

public class LY2 {
	[SectionPosition(1)] public Y2_ContainerDetails ContainerDetails { get; set; } = new();
	[SectionPosition(2)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LY2>(this);
		validator.Required(x => x.ContainerDetails);
		return validator.Results;
	}
}
