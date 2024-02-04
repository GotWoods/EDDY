using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._222;

public class L2000_L2100 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public AT3_BillOfLadingRatesAndCharges BillOfLadingRatesAndCharges { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2100>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 5);
		validator.Required(x => x.BillOfLadingRatesAndCharges);
		return validator.Results;
	}
}
