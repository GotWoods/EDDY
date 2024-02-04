using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Transportation.v5010._309;

public class LP4__LLX_LM12 {
	[SectionPosition(1)] public M12_InBondIdentifyingInformation InBondIdentifyingInformation { get; set; } = new();
	[SectionPosition(2)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LM12>(this);
		validator.Required(x => x.InBondIdentifyingInformation);
		validator.CollectionSize(x => x.PortOrTerminal, 0, 10);
		return validator.Results;
	}
}
