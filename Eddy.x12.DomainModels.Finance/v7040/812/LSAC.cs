using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._812;

public class LSAC {
	[SectionPosition(1)] public SAC_ServicePromotionAllowanceOrChargeInformation ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSAC>(this);
		validator.Required(x => x.ServicePromotionAllowanceOrChargeInformation);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		validator.CollectionSize(x => x.TaxInformation, 0, 10);
		return validator.Results;
	}
}
