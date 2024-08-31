using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17A;

namespace Eddy.Edifact.DomainModels.Transport.D17A.IFTMAN;

public class SegmentGroup19__SegmentGroup31_SegmentGroup33 {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup31_SegmentGroup33>(this);
		validator.Required(x => x.Measurements);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
