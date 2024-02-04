using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._309;

public class LP4__LLX_LVID {
	[SectionPosition(1)] public VID_VehicleID VehicleID { get; set; } = new();
	[SectionPosition(2)] public List<N10_QuantityAndDescription> QuantityAndDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LVID>(this);
		validator.Required(x => x.VehicleID);
		validator.CollectionSize(x => x.QuantityAndDescription, 0, 999);
		return validator.Results;
	}
}
