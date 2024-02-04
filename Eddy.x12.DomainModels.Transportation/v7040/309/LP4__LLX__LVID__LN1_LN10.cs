using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._309;

public class LP4__LLX__LVID__LN1_LN10 {
	[SectionPosition(1)] public N10_QuantityAndDescription QuantityAndDescription { get; set; } = new();
	[SectionPosition(2)] public List<VC_MotorVehicleControl> MotorVehicleControl { get; set; } = new();
	[SectionPosition(3)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(4)] public List<LP4__LLX__LVID__LN1__LN10_LH1> LH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LVID__LN1_LN10>(this);
		validator.Required(x => x.QuantityAndDescription);
		validator.CollectionSize(x => x.MotorVehicleControl, 0, 999);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 0, 999);
		validator.CollectionSize(x => x.LH1, 0, 99);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
