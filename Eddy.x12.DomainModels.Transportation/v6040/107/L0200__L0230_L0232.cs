using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._107;

public class L0200__L0230_L0232 {
	[SectionPosition(1)] public MS2_EquipmentOrContainerOwnerAndType EquipmentOrContainerOwnerAndType { get; set; } = new();
	[SectionPosition(2)] public AT9_TrailerOrContainerDimensionAndWeight? TrailerOrContainerDimensionAndWeight { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0230_L0232>(this);
		validator.Required(x => x.EquipmentOrContainerOwnerAndType);
		return validator.Results;
	}
}
