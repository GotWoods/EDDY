using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._355;

public class LP4__LLX__LM12_LP5 {
	[SectionPosition(1)] public P5_PortInformation PortInformation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LM12_LP5>(this);
		validator.Required(x => x.PortInformation);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
