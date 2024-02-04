using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._355;

public class LP4__LLX__LM12_LR4 {
	[SectionPosition(1)] public R4_PortOrTerminal PortOrTerminal { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LM12_LR4>(this);
		validator.Required(x => x.PortOrTerminal);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
