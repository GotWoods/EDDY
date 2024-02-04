using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._350;

public class LP4_LX4 {
	[SectionPosition(1)] public X4_CustomsReleaseInformation CustomsReleaseInformation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(3)] public List<N7_EquipmentDetails> EquipmentDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LX4>(this);
		validator.Required(x => x.CustomsReleaseInformation);
		validator.CollectionSize(x => x.Remarks, 0, 4);
		validator.CollectionSize(x => x.EquipmentDetails, 1, 999);
		return validator.Results;
	}
}
