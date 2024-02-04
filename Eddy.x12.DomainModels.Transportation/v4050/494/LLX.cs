using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._494;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(3)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 15);
		return validator.Results;
	}
}
