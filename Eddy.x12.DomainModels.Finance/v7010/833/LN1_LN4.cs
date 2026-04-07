using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._833;

public class LN1_LN4 {
	[SectionPosition(1)] public N4_GeographicLocation GeographicLocation { get; set; } = new();
	[SectionPosition(2)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LN4>(this);
		validator.Required(x => x.GeographicLocation);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		return validator.Results;
	}
}
