using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Transportation.v6020._350;

public class LBA1_LX4 {
	[SectionPosition(1)] public X4_CustomsReleaseInformation CustomsReleaseInformation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBA1_LX4>(this);
		validator.Required(x => x.CustomsReleaseInformation);
		validator.CollectionSize(x => x.Remarks, 0, 4);
		return validator.Results;
	}
}
