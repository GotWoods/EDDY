using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._404;

public class LD5 {
	[SectionPosition(1)] public D5_ConsigneesThirdParty ConsigneesThirdParty { get; set; } = new();
	[SectionPosition(2)] public D6_ConsigneesThirdPartyAddress? ConsigneesThirdPartyAddress { get; set; }
	[SectionPosition(3)] public D7_ConsigneesThirdPartyCity? ConsigneesThirdPartyCity { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LD5>(this);
		validator.Required(x => x.ConsigneesThirdParty);
		return validator.Results;
	}
}
