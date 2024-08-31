using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;

namespace Eddy.Edifact.DomainModels.Transport.D99A.IFCSUM;

public class SegmentGroup8_SegmentGroup10 {
	[SectionPosition(1)] public DIM_Dimensions Dimensions { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup8_SegmentGroup10>(this);
		validator.Required(x => x.Dimensions);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
