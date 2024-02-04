using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Transportation.v6010._355;

public class LNM1_LN3 {
	[SectionPosition(1)] public N3_PartyLocation PartyLocation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1_LN3>(this);
		validator.Required(x => x.PartyLocation);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
