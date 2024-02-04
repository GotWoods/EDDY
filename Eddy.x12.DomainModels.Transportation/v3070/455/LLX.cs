using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._455;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public PRM_BasicTraceParameters? BasicTraceParameters { get; set; }
	[SectionPosition(3)] public N1_Name? Name { get; set; }
	[SectionPosition(4)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(5)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		return validator.Results;
	}
}
