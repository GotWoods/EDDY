using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v6030._999;

public class LAK2__LIK3_LIK4 {
	[SectionPosition(1)] public IK4_ImplementationDataElementNote ImplementationDataElementNote { get; set; } = new();
	[SectionPosition(2)] public List<CTX_Context> Context { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAK2__LIK3_LIK4>(this);
		validator.Required(x => x.ImplementationDataElementNote);
		validator.CollectionSize(x => x.Context, 0, 10);
		return validator.Results;
	}
}
