using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._844;

public class LCON__LN1_LSII {
	[SectionPosition(1)] public SII_SalesItemInformation SalesItemInformation { get; set; } = new();
	[SectionPosition(2)] public N9_ReferenceIdentification? ReferenceIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCON__LN1_LSII>(this);
		validator.Required(x => x.SalesItemInformation);
		return validator.Results;
	}
}
