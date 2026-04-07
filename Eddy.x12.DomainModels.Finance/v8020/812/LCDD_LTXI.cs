using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._812;

public class LCDD_LTXI {
	[SectionPosition(1)] public TXI_TaxInformation TaxInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDD_LTXI>(this);
		validator.Required(x => x.TaxInformation);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		return validator.Results;
	}
}
