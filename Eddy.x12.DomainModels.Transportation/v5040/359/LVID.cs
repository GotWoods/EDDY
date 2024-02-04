using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Transportation.v5040._359;

public class LVID {
	[SectionPosition(1)] public VID_ConveyanceIdentification ConveyanceIdentification { get; set; } = new();
	[SectionPosition(2)] public CII_ConveyanceInsuranceInformation? ConveyanceInsuranceInformation { get; set; }
	[SectionPosition(3)] public AAA_RequestValidation? RequestValidation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LVID>(this);
		validator.Required(x => x.ConveyanceIdentification);
		return validator.Results;
	}
}
