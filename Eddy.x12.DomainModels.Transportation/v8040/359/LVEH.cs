using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._359;

public class LVEH {
	[SectionPosition(1)] public VEH_VehicleInformation VehicleInformation { get; set; } = new();
	[SectionPosition(2)] public CII_ConveyanceInsuranceInformation? ConveyanceInsuranceInformation { get; set; }
	[SectionPosition(3)] public AAA_RequestValidation? RequestValidation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LVEH>(this);
		validator.Required(x => x.VehicleInformation);
		return validator.Results;
	}
}
