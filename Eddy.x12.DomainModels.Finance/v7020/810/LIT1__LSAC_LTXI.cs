using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._810;

public class LIT1__LSAC_LTXI {
	[SectionPosition(1)] public TXI_TaxInformation TaxInformation { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIT1__LSAC_LTXI>(this);
		validator.Required(x => x.TaxInformation);
		return validator.Results;
	}
}
