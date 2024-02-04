using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._223;

public class L0200 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		return validator.Results;
	}
}
