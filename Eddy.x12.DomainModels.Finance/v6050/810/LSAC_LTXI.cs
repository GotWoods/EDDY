using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._810;

public class LSAC_LTXI {
	[SectionPosition(1)] public TXI_TaxInformation TaxInformation { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSAC_LTXI>(this);
		validator.Required(x => x.TaxInformation);
		return validator.Results;
	}
}
