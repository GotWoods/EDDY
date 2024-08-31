using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15A;

namespace Eddy.Edifact.DomainModels.Transport.D15A.IFCSUM;

public class SegmentGroup28__SegmentGroup41_SegmentGroup42 {
	[SectionPosition(1)] public TSR_TransportServiceRequirements TransportServiceRequirements { get; set; } = new();
	[SectionPosition(2)] public List<SCC_SchedulingConditions> SchedulingConditions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup41_SegmentGroup42>(this);
		validator.Required(x => x.TransportServiceRequirements);
		validator.CollectionSize(x => x.SchedulingConditions, 1, 9);
		return validator.Results;
	}
}
