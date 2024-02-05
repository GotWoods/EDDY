using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v4060._993;

public class LS4A {
	[SectionPosition(1)] public S4A_AssuranceHeaderLevel2 AssuranceHeaderLevel2 { get; set; } = new();
	[SectionPosition(2)] public SVA_SecurityValue? SecurityValue { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LS4A>(this);
		validator.Required(x => x.AssuranceHeaderLevel2);
		return validator.Results;
	}
}
