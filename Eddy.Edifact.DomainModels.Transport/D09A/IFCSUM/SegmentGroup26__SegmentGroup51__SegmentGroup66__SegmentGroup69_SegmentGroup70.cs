using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09A;

namespace Eddy.Edifact.DomainModels.Transport.D09A.IFCSUM;

public class SegmentGroup26__SegmentGroup51__SegmentGroup66__SegmentGroup69_SegmentGroup70 {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup51__SegmentGroup66__SegmentGroup69_SegmentGroup70>(this);
		validator.Required(x => x.Measurements);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
