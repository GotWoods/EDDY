using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._309;

public class LP4__LLX_LM12 {
	[SectionPosition(1)] public M12_InBondIdentifyingInformation InBondIdentifyingInformation { get; set; } = new();
	[SectionPosition(2)] public List<P5_PortInformation> PortInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LM12>(this);
		validator.Required(x => x.InBondIdentifyingInformation);
		validator.CollectionSize(x => x.PortInformation, 0, 5);
		return validator.Results;
	}
}
