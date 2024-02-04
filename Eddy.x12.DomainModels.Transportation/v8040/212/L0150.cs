using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._212;

public class L0150 {
	[SectionPosition(1)] public AT7_ShipmentStatusDetails ShipmentStatusDetails { get; set; } = new();
	[SectionPosition(2)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(3)] public MS1_EquipmentShipmentOrRealPropertyLocation? EquipmentShipmentOrRealPropertyLocation { get; set; }
	[SectionPosition(4)] public List<L0150_L0160> L0160 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0150>(this);
		validator.Required(x => x.ShipmentStatusDetails);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		foreach (var item in L0160) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
