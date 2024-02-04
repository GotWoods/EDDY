using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Transportation.v5030._224;

public class L0100 {
	[SectionPosition(1)] public CF2_SummaryFreightBillDetail SummaryFreightBillDetail { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100>(this);
		validator.Required(x => x.SummaryFreightBillDetail);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 99);
		return validator.Results;
	}
}
