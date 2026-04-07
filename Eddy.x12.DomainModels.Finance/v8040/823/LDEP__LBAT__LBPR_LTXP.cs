using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._823;

public class LDEP__LBAT__LBPR_LTXP {
	[SectionPosition(1)] public TXP_TaxPayment TaxPayment { get; set; } = new();
	[SectionPosition(2)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP__LBAT__LBPR_LTXP>(this);
		validator.Required(x => x.TaxPayment);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		return validator.Results;
	}
}
