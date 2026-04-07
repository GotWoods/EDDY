using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._822;

public class LENT__LACT_LSER {
	[SectionPosition(1)] public SER_ServiceCharges ServiceCharges { get; set; } = new();
	[SectionPosition(2)] public List<CTP_PricingInformation> PricingInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LACT_LSER>(this);
		validator.Required(x => x.ServiceCharges);
		validator.CollectionSize(x => x.PricingInformation, 0, 99);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		return validator.Results;
	}
}
