using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._194;

public class LN9 {
	[SectionPosition(1)] public N9_ExtendedReferenceInformation ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<MTX_Text> Text { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9>(this);
		validator.Required(x => x.ExtendedReferenceInformation);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		return validator.Results;
	}
}
