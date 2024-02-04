using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._928;

public class LVC {
	[SectionPosition(1)] public VC_MotorVehicleControl MotorVehicleControl { get; set; } = new();
	[SectionPosition(2)] public List<ID_InspectionDetailSegment> InspectionDetailSegment { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LVC>(this);
		validator.Required(x => x.MotorVehicleControl);
		validator.CollectionSize(x => x.InspectionDetailSegment, 0, 99);
		return validator.Results;
	}
}
