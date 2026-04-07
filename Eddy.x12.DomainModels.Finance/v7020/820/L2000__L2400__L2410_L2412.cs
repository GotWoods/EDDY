using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._820;

public class L2000__L2400__L2410_L2412 {
	[SectionPosition(1)] public SAC_ServicePromotionAllowanceOrChargeInformation ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(2)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2400__L2410_L2412>(this);
		validator.Required(x => x.ServicePromotionAllowanceOrChargeInformation);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		return validator.Results;
	}
}
