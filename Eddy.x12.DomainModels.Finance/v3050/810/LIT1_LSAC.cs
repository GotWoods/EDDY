using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._810;

public class LIT1_LSAC {
	[SectionPosition(1)] public SAC_ServicePromotionAllowanceOrChargeInformation ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(2)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIT1_LSAC>(this);
		validator.Required(x => x.ServicePromotionAllowanceOrChargeInformation);
		validator.CollectionSize(x => x.TaxInformation, 0, 10);
		return validator.Results;
	}
}
