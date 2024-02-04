using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._455;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public PRM_BasicTraceParameters? BasicTraceParameters { get; set; }
	[SectionPosition(3)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(4)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(5)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		return validator.Results;
	}
}
