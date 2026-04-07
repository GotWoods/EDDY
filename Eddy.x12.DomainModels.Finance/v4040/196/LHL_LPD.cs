using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._196;

public class LHL_LPD {
	[SectionPosition(1)] public PD_PricingData PricingData { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<PDD_PricingDataDetail> PricingDataDetail { get; set; } = new();
	[SectionPosition(4)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LPD>(this);
		validator.Required(x => x.PricingData);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.PricingDataDetail, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		return validator.Results;
	}
}
