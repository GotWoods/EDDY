using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._410;

public class LS1 {
	[SectionPosition(1)] public S1_StopOffName StopOffName { get; set; } = new();
	[SectionPosition(2)] public S2_StopOffAddress? StopOffAddress { get; set; }
	[SectionPosition(3)] public S9_StopOffStation? StopOffStation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LS1>(this);
		validator.Required(x => x.StopOffName);
		return validator.Results;
	}
}
