using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._820;

public class L2000__L2400__L2420__L2422_L24222 {
	[SectionPosition(1)] public SAC_ServicePromotionAllowanceOrChargeInformation ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(2)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2400__L2420__L2422_L24222>(this);
		validator.Required(x => x.ServicePromotionAllowanceOrChargeInformation);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		return validator.Results;
	}
}
