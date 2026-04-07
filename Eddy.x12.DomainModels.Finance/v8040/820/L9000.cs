using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._820;

public class L9000 {
	[SectionPosition(1)] public TPP_ThirdPartyPayment ThirdPartyPayment { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L9000>(this);
		validator.Required(x => x.ThirdPartyPayment);
		return validator.Results;
	}
}
