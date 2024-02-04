using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._456;

public class LLX_LVC {
	[SectionPosition(1)] public VC_MotorVehicleControl MotorVehicleControl { get; set; } = new();
	[SectionPosition(2)] public List<N1_Name> Name { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LVC>(this);
		validator.Required(x => x.MotorVehicleControl);
		validator.CollectionSize(x => x.Name, 0, 2);
		return validator.Results;
	}
}
