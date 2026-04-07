using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._820;

public class LENT__LADX__LIT1__LSLN_LITA {
	[SectionPosition(1)] public ITA_AllowanceChargeOrService AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(2)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LADX__LIT1__LSLN_LITA>(this);
		validator.Required(x => x.AllowanceChargeOrService);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		return validator.Results;
	}
}
