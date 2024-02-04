using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._361;

public class LCI {
	[SectionPosition(1)] public CI_CarrierInterchangeAgreement CarrierInterchangeAgreement { get; set; } = new();
	[SectionPosition(2)] public K1_Remarks? Remarks { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCI>(this);
		validator.Required(x => x.CarrierInterchangeAgreement);
		return validator.Results;
	}
}
