using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Transportation.v5030._426;

public class L1000_L1300 {
	[SectionPosition(1)] public S1_StopOffName StopOffName { get; set; } = new();
	[SectionPosition(2)] public S9_StopOffStation? StopOffStation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000_L1300>(this);
		validator.Required(x => x.StopOffName);
		return validator.Results;
	}
}
