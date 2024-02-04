using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._417;

public class LS1_LS1 {
	[SectionPosition(1)] public S1_StopOffName StopOffName { get; set; } = new();
	[SectionPosition(2)] public S2_StopOffAddress? StopOffAddress { get; set; }
	[SectionPosition(3)] public S9_StopOffStation? StopOffStation { get; set; }
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LS1_LS1>(this);
		validator.Required(x => x.StopOffName);
		validator.CollectionSize(x => x.DateTimeReference, 0, 4);
		return validator.Results;
	}
}
