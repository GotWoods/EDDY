using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._417;

public class LS1 {
	[SectionPosition(1)] public S1_StopOffName StopOffName { get; set; } = new();
	[SectionPosition(2)] public List<S2_StopOffAddress> StopOffAddress { get; set; } = new();
	[SectionPosition(3)] public S9_StopOffStation? StopOffStation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LS1>(this);
		validator.Required(x => x.StopOffName);
		validator.CollectionSize(x => x.StopOffAddress, 0, 2);
		return validator.Results;
	}
}
