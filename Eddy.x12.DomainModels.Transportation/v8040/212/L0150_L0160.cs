using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._212;

public class L0150_L0160 {
	[SectionPosition(1)] public MS2_EquipmentOrContainerOwnerAndType EquipmentOrContainerOwnerAndType { get; set; } = new();
	[SectionPosition(2)] public M7_SealNumbers? SealNumbers { get; set; }
	[SectionPosition(3)] public AT9_TrailerOrContainerDimensionAndWeight? TrailerOrContainerDimensionAndWeight { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0150_L0160>(this);
		validator.Required(x => x.EquipmentOrContainerOwnerAndType);
		return validator.Results;
	}
}
