using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18A;

namespace Eddy.Edifact.DomainModels.Transport.D18A.IFCSUM;

public class SegmentGroup28__SegmentGroup55__SegmentGroup70__SegmentGroup73_SegmentGroup74 {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup55__SegmentGroup70__SegmentGroup73_SegmentGroup74>(this);
		validator.Required(x => x.Measurements);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
