using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._823;

public class LDEP__LBAT__LBPR__LRMR__LIT1__LSLN_LSAC {
	[SectionPosition(1)] public SAC_ServicePromotionAllowanceOrChargeInformation ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(2)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP__LBAT__LBPR__LRMR__LIT1__LSLN_LSAC>(this);
		validator.Required(x => x.ServicePromotionAllowanceOrChargeInformation);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		return validator.Results;
	}
}
