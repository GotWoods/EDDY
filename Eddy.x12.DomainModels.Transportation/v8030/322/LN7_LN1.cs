using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Transportation.v8030._322;

public class LN7_LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		return validator.Results;
	}
}
