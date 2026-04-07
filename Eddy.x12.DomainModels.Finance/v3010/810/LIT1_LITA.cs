using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.Finance.v3010._810;

public class LIT1_LITA {
	[SectionPosition(1)] public ITA_AllowanceChargeOrService AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(2)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIT1_LITA>(this);
		validator.Required(x => x.AllowanceChargeOrService);
		validator.CollectionSize(x => x.TaxInformation, 0, 10);
		return validator.Results;
	}
}
