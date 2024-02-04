using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._355;

public class LVEH {
	[SectionPosition(1)] public VEH_VehicleInformation VehicleInformation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(3)] public List<LVEH_LM7> LM7 {get;set;} = new();
	[SectionPosition(4)] public List<LVEH_LCII> LCII {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LVEH>(this);
		validator.Required(x => x.VehicleInformation);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		foreach (var item in LM7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCII) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
