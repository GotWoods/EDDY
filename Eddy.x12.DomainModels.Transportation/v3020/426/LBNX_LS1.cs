using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._426;

public class LBNX_LS1 {
	[SectionPosition(1)] public S1_StopOffName StopOffName { get; set; } = new();
	[SectionPosition(2)] public S9_StopOffStation? StopOffStation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBNX_LS1>(this);
		validator.Required(x => x.StopOffName);
		return validator.Results;
	}
}
