using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._404;

public class LF5 {
	[SectionPosition(1)] public F5_ConsignorsThirdParty ConsignorsThirdParty { get; set; } = new();
	[SectionPosition(2)] public F6_ConsignorsThirdPartyAddress? ConsignorsThirdPartyAddress { get; set; }
	[SectionPosition(3)] public F7_ConsignorsThirdPartyCity? ConsignorsThirdPartyCity { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LF5>(this);
		validator.Required(x => x.ConsignorsThirdParty);
		return validator.Results;
	}
}
