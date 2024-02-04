using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._309;

public class LP4__LLX_LVID {
	[SectionPosition(1)] public VID_ConveyanceIdentification ConveyanceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(3)] public List<LP4__LLX__LVID_LN10> LN10 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LVID>(this);
		validator.Required(x => x.ConveyanceIdentification);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 21);
		validator.CollectionSize(x => x.LN10, 0, 999);
		foreach (var item in LN10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
